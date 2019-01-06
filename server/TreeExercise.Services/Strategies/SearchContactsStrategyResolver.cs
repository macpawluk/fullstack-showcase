using System;
using Microsoft.Extensions.DependencyInjection;
using TreeExercise.Services.Enums;

namespace TreeExercise.Services.Strategies
{
	public class SearchContactsStrategyResolver : ISearchContactsStrategyResolver
	{
		private readonly IServiceProvider _serviceProvider;

		public SearchContactsStrategyResolver(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public ISearchContactsStrategy GetSearchContactsStrategy(SearchRangeType searchRangeType)
		{
			switch (searchRangeType)
			{
				case SearchRangeType.Equal:
					return _serviceProvider.GetService<EqualRangeTypeSearchContactsStrategy>();

				case SearchRangeType.LessOrEqual:
					return _serviceProvider.GetService<LessOrEqualRangeTypeSearchContactsStrategy>();

				default:
					throw new NotSupportedException();
			}
		}
	}
}
