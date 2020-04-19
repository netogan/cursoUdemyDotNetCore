using Microsoft.AspNetCore.Mvc;
using RestAppUdemy.Model;
using RestAppUdemy.Business;

namespace RestAppUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        private IBookBusiness _booksBusiness;

        public BooksController(IBookBusiness booksBusiness)
        {
            _booksBusiness = booksBusiness;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var res = _booksBusiness.FindAll();

            return Ok(res);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _booksBusiness.FindById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            return new ObjectResult(_booksBusiness.Create(book));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            var bookUpdate = _booksBusiness.Update(book);

            if (bookUpdate == null)
                return NoContent();

            return new ObjectResult(bookUpdate);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _booksBusiness.Delete(id);

            return NoContent();
        }
    }
}
