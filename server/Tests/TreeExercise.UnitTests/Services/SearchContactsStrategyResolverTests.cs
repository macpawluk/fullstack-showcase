using Moq;
using System;
using TreeExercise.Services.Enums;
using TreeExercise.Services.Strategies;
using Xunit;

namespace TreeExercise.UnitTests.Services
{
	public class SearchContactsStrategyResolverTests
	{
		[Theory]
		[InlineData(SearchRangeType.Equal, typeof(EqualRangeTypeSearchContactsStrategy))]
		[InlineData(SearchRangeType.LessOrEqual, typeof(LessOrEqualRangeTypeSearchContactsStrategy))]
		public void GivenGetCall_WhenRangeTypeEqual_ThenProperStrategyReturned(
			SearchRangeType searchRangeType, 
			Type expectedStrategyType)
		{
			var serviceProviderMock = new Mock<IServiceProvider>();
			serviceProviderMock
				.Setup(sp => sp.GetService(It.IsAny<Type>()));

			var startegyResolver = CreateStartegyResolver(serviceProviderMock.Object);

			startegyResolver.GetSearchContactsStrategy(searchRangeType);

			serviceProviderMock.Verify(
				sp => sp.GetService(It.Is<Type>(type => type == expectedStrategyType)), 
				Times.Once);

		}

		[Fact]
		public void GivenGetCall_WhenRangeTypeUnkown_ThenExceptionThrown()
		{
			var serviceProviderMock = new Mock<IServiceProvider>();
			serviceProviderMock
				.Setup(sp => sp.GetService(It.IsAny<Type>()));

			var startegyResolver = CreateStartegyResolver(serviceProviderMock.Object);

			Assert.Throws<NotSupportedException>(() => startegyResolver.GetSearchContactsStrategy(0));
		}

		private ISearchContactsStrategyResolver CreateStartegyResolver(
			IServiceProvider serviceProvider = null)
		{
			if (serviceProvider == null)
			{
				serviceProvider = Mock.Of<IServiceProvider>();
			}

			return new SearchContactsStrategyResolver(serviceProvider);
		}
	}
}
