using System.Linq;
using System.Threading.Tasks;
using asptest.Data;
using asptest.Models;
using asptest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asptest.Controllers
{
  [Route("v1/account")]
  public class HomeController : ControllerBase
  {
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate(
        [FromServices] DataContext context,
        [FromBody] User model
    )
    {
      var user = await context.Users
        .Where(x => x.Name == model.Name)
        .Where(x => x.Password == model.Password)
        .FirstOrDefaultAsync();

      if (user == null)
      {
        return NotFound(new { message = "Invalid Credentials" });
      }

      var token = TokenService.GenerateToken(user);
      user.Password = "";
      return new { user = user, token = token };
    }

    [HttpGet("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anonymous";

    [HttpGet("authenticated")]
    [Authorize]
    public string Authenticated() => $"Authenticated - {User.Identity.Name}";

    [HttpGet("employee")]
    [Authorize(Roles = "employee,manager")]
    public string Employee() => $"Employee - {User.Identity.Name}";

    [HttpGet("manager")]
    [Authorize(Roles = "manager")]
    public string Manager() => $"Manager - {User.Identity.Name}";


  }


}