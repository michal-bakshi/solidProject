using data.Entites;
using Microsoft.AspNetCore.Mvc;
using servise;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService _userService;
        public UsersController()
        {
            _userService = new UserService();
        }
        // GET: api/<UsersController>
        [HttpGet]
        public List<User> Get()
        {
            return _userService.GetAllUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.GetUserById(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.AddUser(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            _userService.UpdateUser(id, user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
