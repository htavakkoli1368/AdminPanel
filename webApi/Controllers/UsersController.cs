using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Infrastructure;
using webApi.Model;
using webApi.Services.Users;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersInterface usersContext;       

        public UsersController(IUsersInterface users)
        {

            usersContext = users;
        }

   
        [HttpGet("internal")]
        public ActionResult<List<UsersDTO>> GetusersSample()
        {
            return usersContext.GetAllUsers();
        }
       
        [HttpGet("external")]
        public  ActionResult<ExternalUserDTO>  GetusersExternal()
        {
            return usersContext.GetUserExternal();
        }

        // GET: api/Users/5
        [HttpGet("uniqueUser,{id}")]
        public   ActionResult<Users>  GetUsers(int id)
        {
            var users = usersContext.GetUser(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("updateUser,{id}")]
        public  IActionResult PutUsers(int id, UsersUpdateDTO users)
        {

            var updatedUser = usersContext.UpdateUsers(id, users);
             
            if(!updatedUser.IsSuccess)
            {
                return BadRequest("some things wrong happen");
            }

            return Ok(updatedUser);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("newUser")]
        public  ActionResult  PostUsers(UsersDTO users)
        {

           var result =usersContext.AddNewUsers(users);
            if (!result.IsSuccess)
                throw new Exception("Internal Server Error");
           return Ok(result);
        }

        //DELETE: api/Users/5
        [HttpDelete("RemoveUser,{id}")]
        public  IActionResult DeleteUsers(int id)
        {
            var users = usersContext.DeleteUsers(id);
            if (users == null)
            {
                return NotFound();
            }      

            return Ok(users);
        }

        [HttpPost("userExist,{id}")]
        public ActionResult<bool> UsersExists(int id)
        {
            var exist = usersContext.checkUserExist(id);
            return Ok(exist);
        }
    }
}
