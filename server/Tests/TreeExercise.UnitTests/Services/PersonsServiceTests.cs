using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TreeExercise.Infrastructure;
using TreeExercise.Models.Entities;
using TreeExercise.Models.SelectModels;
using TreeExercise.Services;
using TreeExercise.Services.Enums;
using TreeExercise.Services.Strategies;
using TreeExercise.UnitTests.Utils;
using Xunit;

namespace TreeExercise.UnitTests.Services
{
	public class PersonsServiceTests
	{
		[Fact]
		public async Task GivenGetContactsCall_WhenRangeTypeEqual_ThenProperStrategyUsed()
		{
			const int personId = 1;
			const int searchRange = 2;

			var searchStrategyResolverMock = new Mock<ISearchContactsStrategyResolver>();
			var searchStrategyMock = new Mock<ISearchContactsStrategy>();

			searchStrategyResolverMock
				.Setup(r => r.GetSearchContactsStrategy(It.Is<SearchRangeType>(t => t == SearchRangeType.Equal)))
				.Returns(searchStrategyMock.Object);
			searchStrategyMock
				.Setup(s => s.GetPersonContacts(
					It.IsAny<int>(),
					It.IsAny<int>()))
				.ReturnsAsync((PersonWithContacts)null);

			var personsService = CreatePersonsService(
				searchStrategyResolver: searchStrategyResolverMock.Object);

			await personsService.GetPersonContacts(
				personId,
				searchRange, 
				searchRangeType: SearchRangeType.Equal);

			searchStrategyResolverMock
				.Verify(
					r => r.GetSearchContactsStrategy(It.Is<SearchRangeType>(t => t == SearchRangeType.Equal)), 
					Times.Once);
			searchStrategyMock
				.Verify(
					s => s.GetPersonContacts(
						It.Is<int>(id => id == personId), 
						It.Is<int>(range => range == searchRange)), 
					Times.Once);
		}

		[Fact]
		public async Task GivenGetContactsCall_WhenRangeTypeLessOrEqual_ThenProperStrategyUsed()
		{
			const int personId = 1;
			const int searchRange = 2;

			var searchStrategyResolverMock = new Mock<ISearchContactsStrategyResolver>();
			var searchStrategyMock = new Mock<ISearchContactsStrategy>();

			searchStrategyResolverMock
				.Setup(r => r.GetSearchContactsStrategy(It.Is<SearchRangeType>(t => t == SearchRangeType.LessOrEqual)))
				.Returns(searchStrategyMock.Object);
			searchStrategyMock
				.Setup(s => s.GetPersonContacts(
					It.IsAny<int>(),
					It.IsAny<int>()))
				.ReturnsAsync((PersonWithContacts)null);

			var personsService = CreatePersonsService(
				searchStrategyResolver: searchStrategyResolverMock.Object);

			await personsService.GetPersonContacts(
				personId,
				searchRange,
				searchRangeType: SearchRangeType.LessOrEqual);

			searchStrategyResolverMock
				.Verify(
					r => r.GetSearchContactsStrategy(It.Is<SearchRangeType>(t => t == SearchRangeType.LessOrEqual)),
					Times.Once);
			searchStrategyMock
				.Verify(
					s => s.GetPersonContacts(
						It.Is<int>(id => id == personId),
						It.Is<int>(range => range == searchRange)),
					Times.Once);
		}

		[Fact]
		public async Task GivenGetPersonsCall_WhenExecuted_ThenRepositoryUsed()
		{
			var repositoryMock = new Mock<IContactsRepository>();
			repositoryMock.MockSelect<IContactsRepository, Person, PersonDetails>(null);

			var personsService = CreatePersonsService(repositoryMock.Object);

			await personsService.GetAllPersons();

			repositoryMock.VerifySelect<IContactsRepository, Person, PersonDetails>(
				Times.Once, 
				filter: It.Is<Expression<Func<Person, bool>>>(f => f == null));
		}

		private IPersonsService CreatePersonsService(
			IContactsRepository repository = null,
			ISearchContactsStrategyResolver searchStrategyResolver = null)
		{
			if (repository == null)
			{
				repository = Mock.Of<IContactsRepository>();
			}
			if (searchStrategyResolver == null)
			{
				searchStrategyResolver = Mock.Of<ISearchContactsStrategyResolver>();
			}
			return new PersonsService(repository, searchStrategyResolver);
		}
	}
}
