using System.Collections.Generic;
using System.Threading.Tasks;
using asptest.Data;
using asptest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asptest.Controllers
{
  [Route("v1/users")]
  public class UserController : ControllerBase
  {
    [HttpPost("")]
    public async Task<ActionResult<User>> Post(
    [FromServices] DataContext context,
    [FromBody] User model)
    {
      if (ModelState.IsValid)
      {
        context.Users.Add(model);
        await context.SaveChangesAsync();
        model.Password = "";
        return model;
      }
      return BadRequest(ModelState);
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
    {
      var users = await context.Users.ToListAsync();
      foreach (var user in users)
      {
        user.Password = "";
      }
      return users;
    }
  }
}