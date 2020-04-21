using Microsoft.AspNetCore.Mvc;
using RestAppUdemy.Business;
using RestAppUdemy.Data.VO;
using Tapioca.HATEOAS;
using System.Collections.Generic;
using System.Net;

namespace RestAppUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [TypeFilter(typeof(HyperMediaFilter))]
    public class BooksController : ControllerBase
    {
        private IBookBusiness _booksBusiness;

        public BooksController(IBookBusiness booksBusiness)
        {
            _booksBusiness = booksBusiness;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<BookVO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Get()
        {
            var res = _booksBusiness.FindAll();

            return Ok(res);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<BookVO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Get(long id)
        {
            var book = _booksBusiness.FindById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(BookVO), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();

            return new ObjectResult(_booksBusiness.Create(book));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BookVO), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Put([FromBody] BookVO book)
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
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Delete(long id)
        {
            _booksBusiness.Delete(id);

            return NoContent();
        }
    }
}
