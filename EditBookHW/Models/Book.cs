namespace EditBookHW.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Author Author { get; set; }
		public double Price { get; set; }
		public int CountPage { get; set; }

	}
}
