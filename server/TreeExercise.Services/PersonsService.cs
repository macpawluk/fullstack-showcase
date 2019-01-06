using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeExercise.Infrastructure;
using TreeExercise.Models.SelectModels;
using TreeExercise.Services.Enums;
using TreeExercise.Services.Strategies;

namespace TreeExercise.Services
{
	public class PersonsService : IPersonsService
	{
		private readonly IContactsRepository _repository;
		private readonly ISearchContactsStrategyResolver _searchStrategyResolver;

		public PersonsService(
			IContactsRepository repository,
			ISearchContactsStrategyResolver searchStrategyResolver)
		{
			_repository = repository;
			_searchStrategyResolver = searchStrategyResolver;
		}

		public Task<IList<PersonDetails>> GetAllPersons()
		{
			return _repository.SelectAsync(
				select: PersonDetails.FromPerson,
				orderBy: source => source
					.OrderBy(x => x.LastName)
					.ThenBy(x => x.FirstName));
		}

		public async Task<PersonWithContacts> GetPersonContacts(
			int personId, 
			int searchRange, 
			SearchRangeType searchRangeType)
		{
			var searchStrategy = _searchStrategyResolver.GetSearchContactsStrategy(searchRangeType);
			return await searchStrategy.GetPersonContacts(personId, searchRange);
		}
	}
}
