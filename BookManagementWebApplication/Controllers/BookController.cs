using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookManagementWebApplication.Controllers.Services;
using BookManagementWebApplication.Controllers.Model;

namespace BookManagementWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //interface invoke
        private readonly IBookService iBookService;
        public BookController(IBookService BookDetailService)
        {
            iBookService = BookDetailService;
        }
        [HttpPost]
        //Post method
        public IActionResult AddBookPost(AddUpdateBook addNewBook)
        {
            var myBook = iBookService.AddBook(addNewBook);
            return Ok(new
            {
                message = "success"
            });
        }
        [HttpGet]
        //Method for Fetching Book details
        public IActionResult GetBook()
        {
            var AllBookDetails =iBookService.getBookList();
            return Ok(AllBookDetails);

        }
        //method for get by Book Id
        [HttpGet]
        [Route("{id}")]
        public IActionResult getSingleBooKByID(int BookId)
        {
            var getBook = iBookService.GetBookByID(BookId);
            if (getBook != null)
            {
                return Ok(getBook);
            }
            else
            {
                return Ok(new
                {
                    message = "Invalid BookId"
                });
            }
        }
        //method for update book details
        [HttpPut]
        public IActionResult putMethodById(int Id, AddUpdateBook updBook)
        {
            var updateBook = iBookService.UpdateBook(Id, updBook);
            if (updateBook != null)
            {
                return Ok(updateBook);
            }
            return Ok(new
            {
                message = "Book ID not Found"
            });
        }
        //method for delete 
        [HttpDelete]
        public IActionResult DeleteBookById(int BookId)
        {
            var delBookByID = iBookService.DeleteBook(BookId);
            if (delBookByID)
            {
                return Ok(new
                {
                    message = "Book deleted Successfully"
                });
            }
            else
            {
                return NotFound();
            }
        }

    }
}
