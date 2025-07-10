using BookManagementWebApplication.Controllers.Model;


namespace BookManagementWebApplication.Controllers.Services
{
    //logic is implemented in Service class
    public interface IBookService //creating interface followed by 2 methods
    {
        public Book AddBook(AddUpdateBook addUpdateBookObject);
        public List<Book> getBookList();
    }
    public class BookService : IBookService //Inherting with interface
    {
        private readonly List<Book> BookList; //creating in memory collection of list with type Book
        public BookService() //Creating Constructor 
        {
            BookList = new List<Book>()
            {
                //constructor will excute whenever the obj is created
                new Book()
                {
                    BookId=1001,
                    BookTitle="The Jungle Book",
                    Author="JK Rowling",
                    YearPublished=2024,
                    BookGenre="Wild Life",
                    BookPrice=550.50
                }
            };
        }
        //Implementing interface methods
        public Book AddBook(AddUpdateBook AddbookObject)
        {
            var addBook = new Book()
            {
                BookId = BookList.Max(o => o.BookId) + 1, //incrementing Id 
                BookTitle = AddbookObject.BookTitle,
                Author = AddbookObject.Author,
                YearPublished = AddbookObject.YearPublished,
                BookGenre = AddbookObject.BookGenre,
                BookPrice = AddbookObject.BookPrice
            };
            //adding details to list
            BookList.Add(addBook);
            return addBook;
        }
        //Implementing GetBookList interface Method
        public List<Book> getBookList() { 
            return BookList.ToList();  //returning as List
        }
    }
}
