using EditBookHW.Models;
namespace EditBookHW.Data
{
	public class BookDatabase : IDatabase<Book>
	{
		private readonly List<Book> _books;
		public BookDatabase()
		{
			_books = new List<Book>();
		}
		public void Add(Book item)
		{
			_books.Add(item);
		}

		public IEnumerable<Book> Get()
		{
			return _books;
		}

		public void Remove(Book item)
		{
			_books.RemoveAll(x => x.Id == item.Id);
		}

		public void Update(Book oldItem, Book newItem)
		{
			int index = _books.FindIndex(x => x.Id == oldItem.Id);
			_books[index] = newItem;
		}
	}
}
