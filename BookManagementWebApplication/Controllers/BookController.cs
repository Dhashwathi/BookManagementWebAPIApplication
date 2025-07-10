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
    }
}
