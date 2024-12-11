using EditBookHW.Models;
using EditBookHW.Data;
using Microsoft.AspNetCore.Mvc;

namespace EditBookHW.Controllers
{
	public class BookController : Controller
	{
		private static readonly IDatabase<Book> _bookDatabase = new BookDatabase();

		static BookController()
		{
			Author author1 = new Author { Id = 1, Name = "Jack", Birth = DateTime.Now, WriteBooks = 3 };
			Author author2 = new Author { Id = 2, Name = "Alice", Birth = DateTime.Now, WriteBooks = 7 };
			Author author3 = new Author { Id = 3, Name = "Michaele", Birth = DateTime.Now, WriteBooks = 2 };

			_bookDatabase.Add(new Book() { Id = 1, Name = "Hello", Author = author1, Price = 77.5, CountPage= 543 });
			_bookDatabase.Add(new Book() { Id = 2, Name = "Student", Author = author2, Price = 62.5, CountPage = 437 });
			_bookDatabase.Add(new Book() { Id = 3, Name = "IT STEP", Author = author3, Price = 29.5, CountPage = 283 });
		}
		[HttpGet]
		public IActionResult GetBooks()
		{
			var books = _bookDatabase.Get();
			return View(books);
		}
		public IActionResult AddBook()
		{
			return View();
		}
		public IActionResult AddAuthor()
		{
			return View();
		}
		public IActionResult DeleteBook(int id)
		{
			var book = _bookDatabase.Get().First(x => x.Id == id);
			return View(book);
		}
		[HttpPost]
		public IActionResult AddBook(Book book)
		{
			_bookDatabase.Add(book);
			return RedirectToAction(nameof(GetBooks));
		}
		//[HttpPost]
		//public IActionResult AddAuthor(Author aut)
		//{
		//	_bookDatabase.Add(aut);
		//	return RedirectToAction(nameof(GetBooks));
		//}
		[HttpPost]
		public IActionResult DeleteBook(Book book)
		{
			_bookDatabase.Remove(book);
			return RedirectToAction(nameof(GetBooks));
		}
		public IActionResult EditBook(int id) => View(_bookDatabase.Get().First(x => x.Id == id));
		[HttpPost]
		public IActionResult EditBook(Book book)
		{
			var oldbook = _bookDatabase.Get().First(x => x.Id == book.Id);
			_bookDatabase.Update(oldbook, book);
			return RedirectToAction(nameof(GetBooks));
		}
	}
}
