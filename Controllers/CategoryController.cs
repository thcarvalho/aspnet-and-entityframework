using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asptest.Models;
using asptest.Data;
using Microsoft.EntityFrameworkCore;

namespace asptest.Controllers
{
  [ApiController]
  [Route("v1/categories")]
  public class CategoryController : ControllerBase
  {
    [HttpGet("")]
    public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
    {
      var categories = await context.Categories.ToListAsync();
      return categories;
    }

    [HttpPost("")]
    public async Task<ActionResult<Category>> Post(
        [FromServices] DataContext context,
        [FromBody] Category model
    )
    {
      if (ModelState.IsValid)
      {
        context.Categories.Add(model);
        await context.SaveChangesAsync();
        return model;
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}