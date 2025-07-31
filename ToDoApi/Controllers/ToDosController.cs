using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDosController : ControllerBase
    {
        // GET: api/<ToDosController>
        [HttpGet]
        public ActionResult<IEnumerable<ToDoModel>> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ToDosController>/5
        [HttpGet("{id}")]
        public ActionResult<ToDoModel> Get(int id)
        {
            throw new NotImplementedException(); 
        }

        // POST api/<ToDosController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<ToDosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<ToDosController>/5/complete
        [HttpPut("{id}/Complete")]
        public IActionResult Complete(int id)
        {
            throw new NotImplementedException();

        }

        // DELETE api/<ToDosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
