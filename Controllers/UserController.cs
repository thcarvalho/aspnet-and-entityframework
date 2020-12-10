using System.Collections.Generic;
using System.Threading.Tasks;
using asptest.Data;
using asptest.Models;
using asptest.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asptest.Controllers
{
  [Route("v1/users")]
  [ApiController]
  public class UserController : ControllerBase
  {
    [HttpPost("")]
    public async Task<ActionResult<User>> Post(
      [FromServices] IUserRepository userRepository,
      [FromServices] DataContext context,
      [FromBody] User model)
    {
      if (ModelState.IsValid)
      {
        userRepository.Save(model);
        model.Password = "";
        return model;
      }
      return BadRequest(ModelState);
    }

    [HttpGet]
    public Task<ActionResult<List<User>>> Get(
      [FromServices] DataContext context,
      [FromServices] IUserRepository userRepository)
    {
      var users = userRepository.Read();
      return users;
    }
  }
}