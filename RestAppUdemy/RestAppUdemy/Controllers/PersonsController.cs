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
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        [HttpGet]
        //[TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(typeof(List<PersonVO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Get()
        {
            var res = _personBusiness.FindAll();

            return Ok(res);
        }

        [HttpGet("{id}")]
        //[TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(typeof(PersonVO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult GetById(long id)
        {
            var person = _personBusiness.FindById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        ////[TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(typeof(PersonVO), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            person = _personBusiness.Create(person);

            return new ObjectResult(person);
        }

        [HttpPut("{id}")]
        ////[TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(typeof(PersonVO), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            var personUpdate = _personBusiness.Update(person);

            if (personUpdate == null)
                return NoContent();

            return new ObjectResult(personUpdate);
        }

        [HttpPatch("{id}")]
        ////[TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(typeof(PersonVO), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Patch([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            var personUpdate = _personBusiness.Update(person);

            if (personUpdate == null)
                return NoContent();

            return new ObjectResult(personUpdate);
        }

        [HttpDelete("{id}")]
        ////[TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);

            return NoContent();
        }
    }
}
