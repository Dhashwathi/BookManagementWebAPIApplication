using BookManagementWebApplication.Controllers.Model;


namespace BookManagementWebApplication.Controllers.Services
{
    //logic is implemented in Service class
    public interface IBookService //creating interface followed by 2 methods
    {
        //method for adding books
        public Book AddBook(AddUpdateBook addUpdateBookObject);
        //method for getting book
        public List<Book> getBookList();
        //method for deleting book
        public bool DeleteBook(int BookId);
        //method for fetch book by its id
        public Book GetBookByID(int BookId);
        //methode to update book
        public Book UpdateBook(int BookId, AddUpdateBook addUpdateBookObj);

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
        //implementing delete book method
        public bool DeleteBook(int inputBookId)
        {
            var delBook=BookList.FirstOrDefault(b=>b.BookId==inputBookId);
            if (delBook != null)
            {
                BookList.Remove(delBook);
                return true;
            }
            return false;
        }
        //implementing Get Book By ID method
        public Book GetBookByID(int inputbookId)
        {
            var selectBook=BookList.FirstOrDefault(b=>b.BookId == inputbookId);
            return selectBook;
        }
        //implementing Update Book method
        public Book UpdateBook(int  inputBookId,AddUpdateBook AddObj)
        {
            var selectBook = BookList.FirstOrDefault(b => b.BookId == inputBookId);
            if(selectBook!= null)
            {
                selectBook.BookTitle=AddObj.BookTitle;
                selectBook.Author=AddObj.Author;
                selectBook.YearPublished=AddObj.YearPublished;
                selectBook.BookPrice=AddObj.BookPrice;
                selectBook.BookGenre=AddObj.BookGenre;
                return selectBook;
            }
            else
            {
                return null;
            }
        }
    }
}
