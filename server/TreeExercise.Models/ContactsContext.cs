using Microsoft.EntityFrameworkCore;
using TreeExercise.Models.DataSeed;
using TreeExercise.Models.Entities;

namespace TreeExercise.Models
{
	public class ContactsContext : DbContext
	{
		public ContactsContext(DbContextOptions<ContactsContext> options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>()
				.ToTable("Persons")
				.HasKey(p => p.Id);

			modelBuilder.Entity<PersonContact>()
				.ToTable("PersonContacts")
				.HasKey(c => c.Id);
			modelBuilder.Entity<PersonContact>()
				.HasOne(c => c.Person1)
				.WithMany(p => p.Contacts)
				.OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<PersonContact>()
				.HasOne(c => c.Person2);
			modelBuilder.Entity<PersonContact>()
				.HasIndex(p => new { p.Person1Id, p.Person2Id })
				.IsUnique();

			modelBuilder.Seed();
		}

		public DbSet<Person> Persons { get; set; }
	}
}
