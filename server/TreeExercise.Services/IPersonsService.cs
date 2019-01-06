using System.Collections.Generic;
using System.Threading.Tasks;
using TreeExercise.Models.SelectModels;
using TreeExercise.Services.Enums;

namespace TreeExercise.Services
{
	public interface IPersonsService
	{
		Task<IList<PersonDetails>> GetAllPersons();

		Task<PersonWithContacts> GetPersonContacts(
			int personId, 
			int searchRange, 
			SearchRangeType searchRangeType);
	}
}
