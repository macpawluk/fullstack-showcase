using System.Threading.Tasks;
using TreeExercise.Models;
using TreeExercise.Models.Entities;

namespace TreeExercise.IntegrationTests.Utils
{
	public class TestDataBuilder
	{
		private readonly ContactsContext _dbContext;

		public TestDataBuilder(ContactsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public TestDataBuilder AddPerson(
			string firstName,
			string lastName,
			int? id = null)
		{
			var personToAdd = new Person
			{
				FirstName = firstName,
				LastName = lastName
			};
			if (id.HasValue)
			{
				personToAdd.Id = id.Value;
			}
			_dbContext.Add(personToAdd);

			return this;
		}

		public TestDataBuilder AddPersonContact(
			int person1Id,
			int person2Id,
			int? id = null)
		{
			var contactToAdd = new PersonContact
			{
				Person1Id = person1Id,
				Person2Id = person2Id
			};
			if (id.HasValue)
			{
				contactToAdd.Id = id.Value;
			}
			_dbContext.Add(contactToAdd);

			return this;
		}

		public async Task SaveAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
