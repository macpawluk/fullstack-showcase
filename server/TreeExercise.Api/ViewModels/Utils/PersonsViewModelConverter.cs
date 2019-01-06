using System.Collections.Generic;
using System.Linq;
using TreeExercise.Models.SelectModels;

namespace TreeExercise.Api.ViewModels.Utils
{
	public class PersonsViewModelConverter : IPersonsViewModelConverter
	{
		private readonly int _maxDepth;
		private int _rootPersonId;

		public PersonsViewModelConverter(int maxDepth)
		{
			_maxDepth = maxDepth;
		}

		public PersonWithContactsViewModel ConvertToViewModel(PersonWithContacts person)
		{
			_rootPersonId = person.PersonId;

			var rootPerson = CreateViewModelInstance(person);
			PopulateTree(rootPerson, person.Contacts, currentDepth: 1, parentPersonId: null);

			return rootPerson;
		}

		private void PopulateTree(
			PersonWithContactsViewModel personToPopulateContacts, 
			HashSet<PersonWithContacts> contacts, 
			int currentDepth, 
			int? parentPersonId)
		{
			foreach (var person in contacts.Where(p => p.PersonId != personToPopulateContacts.PersonId))
			{
				var personViewModel = CreateViewModelInstance(person);
				personToPopulateContacts.Contacts.Add(personViewModel);

				if (currentDepth < _maxDepth && 
					personViewModel.PersonId != _rootPersonId && 
					personViewModel.PersonId != parentPersonId)
				{
					PopulateTree(personViewModel, person.Contacts, currentDepth + 1, personToPopulateContacts.PersonId);
				}
			}
		}

		private PersonWithContactsViewModel CreateViewModelInstance(PersonWithContacts person)
		{
			return new PersonWithContactsViewModel()
			{
				PersonId = person.PersonId,
				FirstName = person.FirstName,
				LastName = person.LastName
			};
		}
	}
}
