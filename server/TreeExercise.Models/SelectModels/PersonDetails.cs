using System;
using System.Linq.Expressions;
using TreeExercise.Models.Entities;

namespace TreeExercise.Models.SelectModels
{
	public class PersonDetails
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int ContactsCount { get; set; }

		public static Expression<Func<Person, PersonDetails>> FromPerson =
			person => new PersonDetails()
			{
				Id = person.Id,
				FirstName = person.FirstName,
				LastName = person.LastName,
				ContactsCount = person.Contacts.Count
			};
	}
}
