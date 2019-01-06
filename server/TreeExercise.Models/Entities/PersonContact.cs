using System.ComponentModel.DataAnnotations.Schema;

namespace TreeExercise.Models.Entities
{
	public class PersonContact
	{
		public int Id { get; set; }

		public int Person1Id { get; set; }

		public int Person2Id { get; set; }

		[ForeignKey("Person1Id")]
		public Person Person1 { get; set; }

		[ForeignKey("Person2Id")]
		public Person Person2 { get; set; }
	}
}
