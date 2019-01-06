using System.Collections.Generic;

namespace TreeExercise.Api.ViewModels
{
	public class PersonWithContactsViewModel
	{
		public int PersonId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public IList<PersonWithContactsViewModel> Contacts { get; set; } = new List<PersonWithContactsViewModel>();
	}
}
