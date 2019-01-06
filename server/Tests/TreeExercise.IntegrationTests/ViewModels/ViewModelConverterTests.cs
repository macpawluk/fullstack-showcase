using System.Linq;
using System.Threading.Tasks;
using TreeExercise.Api.ViewModels.Utils;
using TreeExercise.IntegrationTests.Utils;
using TreeExercise.Services.Enums;
using Xunit;

namespace TreeExercise.IntegrationTests.ViewModels
{
	public class ViewModelConverterTests
	{
		[Fact]
		public async Task GivenPersonWithContact_WhenConvertingDataCase1_ThenValidViewModelsReturned()
		{
			const int SearchRange = 2;

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
					searchRange: SearchRange,
					searchRangeType: SearchRangeType.LessOrEqual);

				var contacts = personWithContacts.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				var viewModelConverter = new PersonsViewModelConverter(SearchRange);
				var personVm = viewModelConverter.ConvertToViewModel(personWithContacts);

				var contactsVm = personVm.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Equal(2, contactsVm.Count);
				Assert.Single(contactsVm[0].Contacts);
				Assert.Single(contactsVm[1].Contacts);

				Assert.Equal(1, personVm.PersonId);
				Assert.Equal(2, contactsVm[0].PersonId);
				Assert.Equal(3, contactsVm[1].PersonId);

				Assert.Equal(1, contactsVm[0].Contacts.Single().PersonId);
				Assert.Equal(1, contactsVm[1].Contacts.Single().PersonId);

				Assert.Empty(contactsVm[0].Contacts.Single().Contacts);
				Assert.Empty(contactsVm[1].Contacts.Single().Contacts);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenConvertingDataCase2_ThenValidViewModelsReturned()
		{
			const int SearchRange = 2;

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
					searchRange: SearchRange,
					searchRangeType: SearchRangeType.LessOrEqual);

				var viewModelConverter = new PersonsViewModelConverter(SearchRange);
				var personVm = viewModelConverter.ConvertToViewModel(personWithContacts);

				var contactsRootVm = personVm.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Single(contactsRootVm);

				var contactsVm1 = contactsRootVm.Single().Contacts
					.OrderBy(c => c.PersonId)
					.ToList();
				Assert.Equal(2, contactsVm1.Count);

				Assert.Equal(1, contactsVm1[0].PersonId);
				Assert.Equal(3, contactsVm1[1].PersonId);

				Assert.Empty(contactsVm1[1].Contacts);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenConvertingDataCase3_ThenValidViewModelsReturned()
		{
			const int SearchRange = 1;

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
					searchRange: SearchRange,
					searchRangeType: SearchRangeType.LessOrEqual);

				var viewModelConverter = new PersonsViewModelConverter(SearchRange);
				var personVm = viewModelConverter.ConvertToViewModel(personWithContacts);

				var contactsVmRoot = personVm.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Single(contactsVmRoot);

				Assert.Equal(2, contactsVmRoot.Single().PersonId);
				Assert.Empty(contactsVmRoot.Single().Contacts);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenConvertingDataCase4_ThenValidViewModelsReturned()
		{
			const int SearchRange = 2;

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
					searchRange: SearchRange,
					searchRangeType: SearchRangeType.Equal);

				var viewModelConverter = new PersonsViewModelConverter(SearchRange);
				var personVm = viewModelConverter.ConvertToViewModel(personWithContacts);

				var contactsRootVm = personVm.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Single(contactsRootVm);
				Assert.Equal(3, contactsRootVm.Single().PersonId);
				Assert.Empty(contactsRootVm.Single().Contacts);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenConvertingDataCase5_ThenValidViewModelsReturned()
		{
			const int SearchRange = 1;

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
					searchRange: SearchRange,
					searchRangeType: SearchRangeType.Equal);

				var viewModelConverter = new PersonsViewModelConverter(SearchRange);
				var personVm = viewModelConverter.ConvertToViewModel(personWithContacts);

				var contactsRootVm = personVm.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Single(contactsRootVm);
				Assert.Equal(2, contactsRootVm.Single().PersonId);
				Assert.Empty(contactsRootVm.Single().Contacts);
			}
		}

		[Fact]
		public async Task GivenPersonWithContact_WhenConvertingDataCase6_ThenValidViewModelsReturned()
		{
			const int SearchRange = 2;

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
					searchRange: SearchRange,
					searchRangeType: SearchRangeType.LessOrEqual);

				var viewModelConverter = new PersonsViewModelConverter(SearchRange);
				var personVm = viewModelConverter.ConvertToViewModel(personWithContacts);

				var contactsRootVm = personVm.Contacts
					.OrderBy(c => c.PersonId)
					.ToList();

				Assert.Equal(1, personVm.PersonId);
				Assert.Empty(contactsRootVm);
			}
		}
	}
}
