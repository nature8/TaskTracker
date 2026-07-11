/*using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private static readonly List<User> Users = new()
    {
        new User(1, "Alice", "alice@example.com"),
        new User(2, "Bob", "bob@example.com")
    };

    [HttpGet]
    public IActionResult Get() => Ok(Users);

    [HttpPost]
    public IActionResult Add(User user)
    {
        Users.Add(user);
        return Ok(user);
    }
}
*/

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> Users = new()
        {
            new User(1, "Alice", "alice@example.com"),
            new User(2, "Bob", "bob@example.com")
        };

        // Health Endpoint
        [AllowAnonymous]
        [HttpGet("alive")]
        public IActionResult Alive()
        {
            return Ok("UserService OK");
        }

        // Get Users
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users);
        }

        // Add User
        [Authorize]
        [HttpPost]
        public IActionResult Add(User user)
        {
            Users.Add(user);
            return Ok(user);
        }
    }
}