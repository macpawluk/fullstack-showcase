using TreeExercise.Models.SelectModels;

namespace TreeExercise.Api.ViewModels.Utils
{
	public interface IPersonsViewModelConverter
	{
		PersonWithContactsViewModel ConvertToViewModel(PersonWithContacts person);
	}
}
