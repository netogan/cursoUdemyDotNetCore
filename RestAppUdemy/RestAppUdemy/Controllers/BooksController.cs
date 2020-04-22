using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAppUdemy.Business;
using RestAppUdemy.Data.VO;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace RestAppUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [Authorize("Bearer")]
    public class BooksController : ControllerBase
    {
        private IBookBusiness _booksBusiness;

        public BooksController(IBookBusiness booksBusiness)
        {
            _booksBusiness = booksBusiness;
        }

        [HttpGet]
        //[TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(typeof(List<BookVO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Get()
        {
            var res = _booksBusiness.FindAll();

            return Ok(res);
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        //[TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(typeof(List<BookVO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult GetById(long id)
        {
            var book = _booksBusiness.FindById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        //[TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(typeof(BookVO), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();

            return new ObjectResult(_booksBusiness.Create(book));
        }

        [HttpPut("{id}")]
        //[TypeFilter(typeof(HyperMediaFilter))]
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

        [HttpDelete("{id}")]
        //[TypeFilter(typeof(HyperMediaFilter))]
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
