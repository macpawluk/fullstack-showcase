using System.Linq;
using System.Threading.Tasks;
using TreeExercise.IntegrationTests.Utils;
using TreeExercise.Services.Enums;
using Xunit;

namespace TreeExercise.IntegrationTests.Services
{
	public class PersonsServiceTests
	{
		[Fact]
		public async Task GivenPopulatedRepository_WhenAllPersonsQueried_ThenValidDataReturned()
		{
			using (var dbContext = TestDbContextFactory.CreateContext())
			{
				var dataBuilder = new TestDataBuilder(dbContext);

				dataBuilder
					.AddPerson("John", "Doe")
					.AddPerson("Joan", "Doe");

				await dataBuilder.SaveAsync();

				var personsService = TetstServicesFactory.CreatePersonsService(dbContext);

				var persons = await personsService.GetAllPersons();

				Assert.Equal(2, persons.Count);

				Assert.Equal("Joan", persons[0].FirstName);
				Assert.Equal("Doe", persons[0].LastName);
				Assert.Equal(0, persons[0].ContactsCount);

				Assert.Equal("John", persons[1].FirstName);
				Assert.Equal("Doe", persons[1].LastName);
				Assert.Equal(0, persons[1].ContactsCount);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenQueriedWithParamsCase1_ThenValidDataReturned()
		{
			using (var dbContext = TestDbContextFactory.CreateContext())
			{
				var dataBuilder = new TestDataBuilder(dbContext);

				dataBuilder
					.AddPerson("Main", "Person", id: 1)
					.AddPerson("Contact", "1", id: 2)
					.AddPerson("Contact", "2", id: 3)
					.AddPersonContact(1, 2)
					.AddPersonContact(2, 1)
					.AddPersonContact(1, 3)
					.AddPersonContact(3, 1);

				await dataBuilder.SaveAsync();

				var personsService = TetstServicesFactory.CreatePersonsService(dbContext);

				var personWithContacts = await personsService.GetPersonContacts(
					personId: 1, 
					searchRange: 2, 
					searchRangeType: SearchRangeType.LessOrEqual);

				var contacts = personWithContacts.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();
				
				Assert.Equal(2, contacts.Count);
				Assert.Single(contacts[0].Contacts);
				Assert.Single(contacts[1].Contacts);

				Assert.Equal(1, personWithContacts.PersonId);
				Assert.Equal(2, contacts[0].PersonId);
				Assert.Equal(3, contacts[1].PersonId);

				Assert.Equal(1, contacts[0].Contacts.Single().PersonId);
				Assert.Equal(1, contacts[1].Contacts.Single().PersonId);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenQueriedWithParamsCase2_ThenValidDataReturned()
		{
			using (var dbContext = TestDbContextFactory.CreateContext())
			{
				var dataBuilder = new TestDataBuilder(dbContext);

				dataBuilder
					.AddPerson("Main", "Person", id: 1)
					.AddPerson("Contact", "1", id: 2)
					.AddPerson("Contact", "2", id: 3)
					.AddPersonContact(1, 2)
					.AddPersonContact(2, 1)
					.AddPersonContact(3, 2)
					.AddPersonContact(2, 3);

				await dataBuilder.SaveAsync();

				var personsService = TetstServicesFactory.CreatePersonsService(dbContext);

				var personWithContacts = await personsService.GetPersonContacts(
					personId: 1,
					searchRange: 2,
					searchRangeType: SearchRangeType.LessOrEqual);

				var contactsRoot = personWithContacts.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Single(contactsRoot);

				var contacts1 = contactsRoot.Single().Contacts
					.OrderBy(c => c.PersonId)
					.ToList();
				Assert.Equal(2, contacts1.Count);

				Assert.Equal(1, contacts1[0].PersonId);
				Assert.Equal(3, contacts1[1].PersonId);

				Assert.Single(contacts1[1].Contacts);
				Assert.Equal(2, contacts1[1].Contacts.Single().PersonId);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenQueriedWithParamsCase3_ThenValidDataReturned()
		{
			using (var dbContext = TestDbContextFactory.CreateContext())
			{
				var dataBuilder = new TestDataBuilder(dbContext);

				dataBuilder
					.AddPerson("Main", "Person", id: 1)
					.AddPerson("Contact", "1", id: 2)
					.AddPerson("Contact", "2", id: 3)
					.AddPersonContact(1, 2)
					.AddPersonContact(2, 1)
					.AddPersonContact(3, 2)
					.AddPersonContact(2, 3);

				await dataBuilder.SaveAsync();

				var personsService = TetstServicesFactory.CreatePersonsService(dbContext);

				var personWithContacts = await personsService.GetPersonContacts(
					personId: 1,
					searchRange: 1,
					searchRangeType: SearchRangeType.LessOrEqual);

				var contactsRoot = personWithContacts.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Single(contactsRoot);

				Assert.Equal(2, contactsRoot.Single().PersonId);
				Assert.Equal(1, contactsRoot.Single().Contacts.Single().PersonId);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenQueriedWithParamsCase4_ThenValidDataReturned()
		{
			using (var dbContext = TestDbContextFactory.CreateContext())
			{
				var dataBuilder = new TestDataBuilder(dbContext);

				dataBuilder
					.AddPerson("Main", "Person", id: 1)
					.AddPerson("Contact", "1", id: 2)
					.AddPerson("Contact", "2", id: 3)
					.AddPersonContact(1, 2)
					.AddPersonContact(2, 1)
					.AddPersonContact(3, 2)
					.AddPersonContact(2, 3);

				await dataBuilder.SaveAsync();

				var personsService = TetstServicesFactory.CreatePersonsService(dbContext);

				var personWithContacts = await personsService.GetPersonContacts(
					personId: 1,
					searchRange: 2,
					searchRangeType: SearchRangeType.Equal);

				var contactsRoot = personWithContacts.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Single(contactsRoot);
				Assert.Equal(3, contactsRoot.Single().PersonId);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenQueriedWithParamsCase5_ThenValidDataReturned()
		{
			using (var dbContext = TestDbContextFactory.CreateContext())
			{
				var dataBuilder = new TestDataBuilder(dbContext);

				dataBuilder
					.AddPerson("Main", "Person", id: 1)
					.AddPerson("Contact", "1", id: 2)
					.AddPerson("Contact", "2", id: 3)
					.AddPersonContact(1, 2)
					.AddPersonContact(2, 1)
					.AddPersonContact(3, 2)
					.AddPersonContact(2, 3);

				await dataBuilder.SaveAsync();

				var personsService = TetstServicesFactory.CreatePersonsService(dbContext);

				var personWithContacts = await personsService.GetPersonContacts(
					personId: 1,
					searchRange: 1,
					searchRangeType: SearchRangeType.Equal);

				var contactsRoot = personWithContacts.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Single(contactsRoot);
				Assert.Equal(2, contactsRoot.Single().PersonId);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenQueriedWithParamsCase6_ThenValidDataReturned()
		{
			using (var dbContext = TestDbContextFactory.CreateContext())
			{
				var dataBuilder = new TestDataBuilder(dbContext);

				dataBuilder
					.AddPerson("Main", "Person", id: 1)
					.AddPerson("Contact", "1", id: 2)
					.AddPerson("Contact", "2", id: 3)
					.AddPerson("Contact", "3", id: 4)
					.AddPersonContact(2, 3)
					.AddPersonContact(3, 2)
					.AddPersonContact(4, 3)
					.AddPersonContact(3, 4);

				await dataBuilder.SaveAsync();

				var personsService = TetstServicesFactory.CreatePersonsService(dbContext);

				var personWithContacts = await personsService.GetPersonContacts(
					personId: 1,
					searchRange: 2,
					searchRangeType: SearchRangeType.LessOrEqual);

				var contactsRoot = personWithContacts.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Equal(1, personWithContacts.PersonId);
				Assert.Empty(contactsRoot);
			}
		}
	}
}
