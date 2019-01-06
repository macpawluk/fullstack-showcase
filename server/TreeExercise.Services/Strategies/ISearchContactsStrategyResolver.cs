using TreeExercise.Services.Enums;

namespace TreeExercise.Services.Strategies
{
	public interface ISearchContactsStrategyResolver
	{
		ISearchContactsStrategy GetSearchContactsStrategy(SearchRangeType searchRangeType);
	}
}
