using System.Collections.Generic;

namespace TreeExercise.Models.Entities
{
	public class Person
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public IList<PersonContact> Contacts { get; set; }
	}
}
