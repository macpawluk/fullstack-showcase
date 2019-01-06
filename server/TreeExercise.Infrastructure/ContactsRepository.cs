using TreeExercise.Models;

namespace TreeExercise.Infrastructure
{
	public class ContactsRepository : Repository, IContactsRepository
	{
		public ContactsRepository(ContactsContext dbContext)
			: base(dbContext)
		{
		}
	}
}
