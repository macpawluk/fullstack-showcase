using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeExercise.Infrastructure;
using TreeExercise.Models;
using TreeExercise.Models.Entities;
using TreeExercise.Models.SelectModels;

namespace TreeExercise.Services.Strategies
{
	public class LessOrEqualRangeTypeSearchContactsStrategy : ISearchContactsStrategy
	{
		private readonly IContactsRepository _repository;

		public LessOrEqualRangeTypeSearchContactsStrategy(IContactsRepository repository)
		{
			_repository = repository;
		}

		public async Task<PersonWithContacts> GetPersonContacts(int personId, int searchRange)
		{
			var personsToFetch = new List<int>() { personId };
			var personsDictionary = new Dictionary<int, PersonWithContacts>();

			for (int i = 0; i < searchRange + 1; i++)
			{
				var persons = await _repository.WhereAsync<Person>(
					filter: person => personsToFetch.Any(c => c == person.Id),
					include: source => source.Include(person => person.Contacts));

				foreach (var person in persons.Where(person => !personsDictionary.ContainsKey(person.Id)))
				{
					personsDictionary[person.Id] = person.ConvertToPersonWithContacts();
				}

				foreach (var person in persons)
				{
					foreach (var contact in person.Contacts)
					{
						if (!personsDictionary.ContainsKey(contact.Person1Id) ||
							!personsDictionary.ContainsKey(contact.Person2Id))
						{
							continue;
						}
						personsDictionary[contact.Person1Id].Contacts.Add(personsDictionary[contact.Person2Id]);
						personsDictionary[contact.Person2Id].Contacts.Add(personsDictionary[contact.Person1Id]);
					}
				}

				personsToFetch = persons
					.SelectMany(p => p.Contacts)
					.Select(c => c.Person2Id)
					.Distinct()
					.ToList();
			}

			return personsDictionary[personId];
		}
	}
}
