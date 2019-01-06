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
	public class EqualRangeTypeSearchContactsStrategy : ISearchContactsStrategy
	{
		private readonly IContactsRepository _repository;

		public EqualRangeTypeSearchContactsStrategy(IContactsRepository repository)
		{
			_repository = repository;
		}

		public async Task<PersonWithContacts> GetPersonContacts(int personId, int searchRange)
		{
			PersonWithContacts rootPerson = null;
			var personsIds = new HashSet<int>();
			var personsToFetch = new List<int>() { personId };

			for (int i = 0; i < searchRange; i++)
			{
				var personsWithContacts = await _repository.WhereAsync<Person>(
					filter: person => personsToFetch.Any(c => c == person.Id),
					include: source => source.Include(person => person.Contacts));

				if (i == 0)
				{
					rootPerson = personsWithContacts
						.First()
						.ConvertToPersonWithContacts();
				}

				personsWithContacts
					.Where(person => !personsIds.Contains(person.Id))
					.ToList()
					.ForEach(person => personsIds.Add(person.Id));

				personsToFetch = personsWithContacts
					.SelectMany(p => p.Contacts)
					.Select(c => c.Person2Id)
					.Distinct()
					.ToList();
			}

			var persons = await _repository.WhereAsync<Person>(
					filter: person => personsToFetch.Any(c => c == person.Id));

			var closerContactsIds = personsIds.ToList();

			var furterContacts = persons
				.Where(p => !closerContactsIds.Contains(p.Id))
				.ToList();

			rootPerson.Contacts = furterContacts
				.Select(person => person.ConvertToPersonWithContacts())
				.ToHashSet();

			return rootPerson;
		}
	}
}
