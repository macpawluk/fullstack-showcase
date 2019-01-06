using System.Threading.Tasks;
using TreeExercise.Models.SelectModels;

namespace TreeExercise.Services.Strategies
{
	public interface ISearchContactsStrategy
	{
		Task<PersonWithContacts> GetPersonContacts(int personId, int searchRange);
	}
}
