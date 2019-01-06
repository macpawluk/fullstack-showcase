using Microsoft.EntityFrameworkCore;
using TreeExercise.Models.Entities;

namespace TreeExercise.Models.DataSeed
{
	public static class DataSeedExtensions
	{
		private const int OliverId = 1;
		private const int AmeliaId = 2;
		private const int MikeId = 3;
		private const int JackId = 4;
		private const int HarryId = 5;
		private const int JacobId = 6;
		private const int CharlieId = 7;
		private const int OliviaId = 8;
		private const int EmilyId = 9;
		private const int ThomasId = 10;
		private const int SophieId = 11;
		private const int AnthonyId = 12;
		private const int JessicaId = 13;
		private const int JamesId = 14;
		private const int WilliamId = 15;
		private const int LilyId = 16;
		private const int MeganId = 17;
		private const int KyleId = 18;
		private const int SamanthaId = 19;
		private const int MargaretId = 20;
		private const int DavidId = 21;
		private const int FreddyId = 22;

		public static void Seed(this ModelBuilder modelBuilder)
		{
			SeedPersons(modelBuilder);
			SeedPersonContacts(modelBuilder);
		}

		private static void SeedPersons(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>().HasData(
				new Person
				{
					Id = OliverId,
					FirstName = "Oliver",
					LastName = "-"
				},
				new Person
				{
					Id = AmeliaId,
					FirstName = "Amelia",
					LastName = "-"
				},
				new Person
				{
					Id = MikeId,
					FirstName = "Mike",
					LastName = "-"
				},
				new Person
				{
					Id = JackId,
					FirstName = "Jack",
					LastName = "-"
				},
				new Person
				{
					Id = HarryId,
					FirstName = "Harry",
					LastName = "-"
				},
				new Person
				{
					Id = JacobId,
					FirstName = "Jacob",
					LastName = "-"
				},
				new Person
				{
					Id = CharlieId,
					FirstName = "Charlie",
					LastName = "-"
				},
				new Person
				{
					Id = OliviaId,
					FirstName = "Olivia",
					LastName = "-"
				},
				new Person
				{
					Id = EmilyId,
					FirstName = "Emily",
					LastName = "-"
				},
				new Person
				{
					Id = ThomasId,
					FirstName = "Thomas",
					LastName = "-"
				},
				new Person
				{
					Id = SophieId,
					FirstName = "Sophie",
					LastName = "-"
				},
				new Person
				{
					Id = AnthonyId,
					FirstName = "Anthony",
					LastName = "-"
				},
				new Person
				{
					Id = JessicaId,
					FirstName = "Jessica",
					LastName = "-"
				},
				new Person
				{
					Id = JamesId,
					FirstName = "James",
					LastName = "-"
				},
				new Person
				{
					Id = WilliamId,
					FirstName = "William",
					LastName = "-"
				},
				new Person
				{
					Id = LilyId,
					FirstName = "Lily",
					LastName = "-"
				},
				new Person
				{
					Id = MeganId,
					FirstName = "Megan",
					LastName = "-"
				},
				new Person
				{
					Id = KyleId,
					FirstName = "Kyle",
					LastName = "-"
				},
				new Person
				{
					Id = SamanthaId,
					FirstName = "Samantha",
					LastName = "-"
				},
				new Person
				{
					Id = MargaretId,
					FirstName = "Margaret",
					LastName = "-"
				},
				new Person
				{
					Id = DavidId,
					FirstName = "David",
					LastName = "-"
				},
				new Person
				{
					Id = FreddyId,
					FirstName = "Freddy",
					LastName = "-"
				}
			);
		}

		private static void SeedPersonContacts(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PersonContact>().HasData(
				// FreddyId
				new PersonContact
				{
					Id = 1,
					Person1Id = OliverId,
					Person2Id = AmeliaId
				},
				new PersonContact
				{
					Id = 76,
					Person1Id = OliverId,
					Person2Id = MikeId
				},

				// Amelia
				new PersonContact
				{
					Id = 2,
					Person1Id = AmeliaId,
					Person2Id = OliverId
				},
				new PersonContact
				{
					Id = 3,
					Person1Id = AmeliaId,
					Person2Id = MikeId
				},

				// Mike
				new PersonContact
				{
					Id = 4,
					Person1Id = MikeId,
					Person2Id = AmeliaId
				},
				new PersonContact
				{
					Id = 5,
					Person1Id = MikeId,
					Person2Id = AnthonyId
				},
				new PersonContact
				{
					Id = 6,
					Person1Id = MikeId,
					Person2Id = JessicaId
				},
				new PersonContact
				{
					Id = 7,
					Person1Id = MikeId,
					Person2Id = SophieId
				},
				new PersonContact
				{
					Id = 8,
					Person1Id = MikeId,
					Person2Id = ThomasId
				},
				new PersonContact
				{
					Id = 9,
					Person1Id = MikeId,
					Person2Id = EmilyId
				},
				new PersonContact
				{
					Id = 10,
					Person1Id = MikeId,
					Person2Id = OliviaId
				},
				new PersonContact
				{
					Id = 11,
					Person1Id = MikeId,
					Person2Id = HarryId
				},
				new PersonContact
				{
					Id = 12,
					Person1Id = MikeId,
					Person2Id = JackId
				},
				new PersonContact
				{
					Id = 77,
					Person1Id = MikeId,
					Person2Id = OliverId
				},

				// Anthony
				new PersonContact
				{
					Id = 13,
					Person1Id = AnthonyId,
					Person2Id = MikeId
				},
				new PersonContact
				{
					Id = 14,
					Person1Id = AnthonyId,
					Person2Id = SophieId
				},
				new PersonContact
				{
					Id = 15,
					Person1Id = AnthonyId,
					Person2Id = JessicaId
				},
				new PersonContact
				{
					Id = 16,
					Person1Id = AnthonyId,
					Person2Id = JamesId
				},
				new PersonContact
				{
					Id = 17,
					Person1Id = AnthonyId,
					Person2Id = WilliamId
				},

				// Sophie
				new PersonContact
				{
					Id = 18,
					Person1Id = SophieId,
					Person2Id = MikeId
				},
				new PersonContact
				{
					Id = 19,
					Person1Id = SophieId,
					Person2Id = HarryId
				},
				new PersonContact
				{
					Id = 20,
					Person1Id = SophieId,
					Person2Id = AnthonyId
				},
				new PersonContact
				{
					Id = 21,
					Person1Id = SophieId,
					Person2Id = JessicaId
				},
				new PersonContact
				{
					Id = 22,
					Person1Id = SophieId,
					Person2Id = LilyId
				},
				new PersonContact
				{
					Id = 23,
					Person1Id = SophieId,
					Person2Id = MeganId
				},

				// Jessica
				new PersonContact
				{
					Id = 24,
					Person1Id = JessicaId,
					Person2Id = AnthonyId
				},
				new PersonContact
				{
					Id = 25,
					Person1Id = JessicaId,
					Person2Id = SophieId
				},
				new PersonContact
				{
					Id = 26,
					Person1Id = JessicaId,
					Person2Id = MikeId
				},
				new PersonContact
				{
					Id = 27,
					Person1Id = JessicaId,
					Person2Id = SamanthaId
				},
				new PersonContact
				{
					Id = 28,
					Person1Id = JessicaId,
					Person2Id = MargaretId
				},

				// Samantha
				new PersonContact
				{
					Id = 29,
					Person1Id = SamanthaId,
					Person2Id = JessicaId
				},
				new PersonContact
				{
					Id = 30,
					Person1Id = SamanthaId,
					Person2Id = MargaretId
				},

				// Margaret
				new PersonContact
				{
					Id = 31,
					Person1Id = MargaretId,
					Person2Id = JessicaId
				},
				new PersonContact
				{
					Id = 32,
					Person1Id = MargaretId,
					Person2Id = SamanthaId
				},

				// Jack
				new PersonContact
				{
					Id = 33,
					Person1Id = JackId,
					Person2Id = MikeId
				},
				new PersonContact
				{
					Id = 34,
					Person1Id = JackId,
					Person2Id = CharlieId
				},
				new PersonContact
				{
					Id = 36,
					Person1Id = JackId,
					Person2Id = HarryId
				},

				// Harry
				new PersonContact
				{
					Id = 37,
					Person1Id = HarryId,
					Person2Id = JackId
				},
				new PersonContact
				{
					Id = 38,
					Person1Id = HarryId,
					Person2Id = CharlieId
				},
				new PersonContact
				{
					Id = 39,
					Person1Id = HarryId,
					Person2Id = MikeId
				},
				new PersonContact
				{
					Id = 40,
					Person1Id = HarryId,
					Person2Id = SophieId
				},
				new PersonContact
				{
					Id = 41,
					Person1Id = HarryId,
					Person2Id = OliviaId
				},
				new PersonContact
				{
					Id = 42,
					Person1Id = HarryId,
					Person2Id = EmilyId
				},

				// Charlie
				new PersonContact
				{
					Id = 43,
					Person1Id = CharlieId,
					Person2Id = JackId
				},
				new PersonContact
				{
					Id = 44,
					Person1Id = CharlieId,
					Person2Id = HarryId
				},

				// Olivia
				new PersonContact
				{
					Id = 45,
					Person1Id = OliviaId,
					Person2Id = MikeId
				},
				new PersonContact
				{
					Id = 46,
					Person1Id = OliviaId,
					Person2Id = HarryId
				},
				new PersonContact
				{
					Id = 47,
					Person1Id = OliviaId,
					Person2Id = JacobId
				},
				new PersonContact
				{
					Id = 48,
					Person1Id = OliviaId,
					Person2Id = EmilyId
				},
				new PersonContact
				{
					Id = 49,
					Person1Id = OliviaId,
					Person2Id = ThomasId
				},

				// Jacob
				new PersonContact
				{
					Id = 50,
					Person1Id = JacobId,
					Person2Id = OliviaId
				},
				new PersonContact
				{
					Id = 51,
					Person1Id = JacobId,
					Person2Id = EmilyId
				},

				// Emily
				new PersonContact
				{
					Id = 52,
					Person1Id = EmilyId,
					Person2Id = MikeId
				},
				new PersonContact
				{
					Id = 53,
					Person1Id = EmilyId,
					Person2Id = OliviaId
				},
				new PersonContact
				{
					Id = 54,
					Person1Id = EmilyId,
					Person2Id = JacobId
				},
				new PersonContact
				{
					Id = 55,
					Person1Id = EmilyId,
					Person2Id = HarryId
				},

				// Thomas
				new PersonContact
				{
					Id = 56,
					Person1Id = ThomasId,
					Person2Id = MikeId
				},
				new PersonContact
				{
					Id = 57,
					Person1Id = ThomasId,
					Person2Id = OliviaId
				},

				// James
				new PersonContact
				{
					Id = 58,
					Person1Id = JamesId,
					Person2Id = AnthonyId
				},
				new PersonContact
				{
					Id = 59,
					Person1Id = JamesId,
					Person2Id = WilliamId
				},
				new PersonContact
				{
					Id = 60,
					Person1Id = JamesId,
					Person2Id = LilyId
				},

				// William
				new PersonContact
				{
					Id = 61,
					Person1Id = WilliamId,
					Person2Id = AnthonyId
				},
				new PersonContact
				{
					Id = 62,
					Person1Id = WilliamId,
					Person2Id = JamesId
				},
				new PersonContact
				{
					Id = 63,
					Person1Id = WilliamId,
					Person2Id = MeganId
				},
				new PersonContact
				{
					Id = 64,
					Person1Id = WilliamId,
					Person2Id = KyleId
				},

				// Lily
				new PersonContact
				{
					Id = 65,
					Person1Id = LilyId,
					Person2Id = SophieId
				},
				new PersonContact
				{
					Id = 66,
					Person1Id = LilyId,
					Person2Id = JamesId
				},
				new PersonContact
				{
					Id = 67,
					Person1Id = LilyId,
					Person2Id = MeganId
				},

				// Megan
				new PersonContact
				{
					Id = 68,
					Person1Id = MeganId,
					Person2Id = SophieId
				},
				new PersonContact
				{
					Id = 69,
					Person1Id = MeganId,
					Person2Id = WilliamId
				},
				new PersonContact
				{
					Id = 70,
					Person1Id = MeganId,
					Person2Id = LilyId
				},
				new PersonContact
				{
					Id = 71,
					Person1Id = MeganId,
					Person2Id = KyleId
				},

				// Kyle
				new PersonContact
				{
					Id = 72,
					Person1Id = KyleId,
					Person2Id = MeganId
				},
				new PersonContact
				{
					Id = 73,
					Person1Id = KyleId,
					Person2Id = WilliamId
				},

				// David
				new PersonContact
				{
					Id = 74,
					Person1Id = DavidId,
					Person2Id = FreddyId
				},

				// Freddy
				new PersonContact
				{
					Id = 75,
					Person1Id = FreddyId,
					Person2Id = DavidId
				}
			);
		}
	}
}
