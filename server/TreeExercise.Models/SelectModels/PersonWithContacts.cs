using System.Collections.Generic;

namespace TreeExercise.Models.SelectModels
{
	public class PersonWithContacts
	{
		public int PersonId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public HashSet<PersonWithContacts> Contacts { get; set; } = new HashSet<PersonWithContacts>();
	}
}
