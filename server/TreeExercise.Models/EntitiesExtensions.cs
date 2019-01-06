using TreeExercise.Models.Entities;
using TreeExercise.Models.SelectModels;

namespace TreeExercise.Models
{
	public static class EntitiesExtensions
	{
		public static PersonWithContacts ConvertToPersonWithContacts(this Person person)
		{
			return new PersonWithContacts
			{
				PersonId = person.Id,
				FirstName = person.FirstName,
				LastName = person.LastName
			};
		}
	}
}
