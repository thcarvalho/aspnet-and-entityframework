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
  [Route("v1/products")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    [HttpGet("")]
    public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
    {
      var products = await context.Products.Include(x => x.Category).ToListAsync();
      return products;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
    {
      var product = await context.Products
      .Include(x => x.Category)
      .AsNoTracking()
      .FirstOrDefaultAsync(x => x.Id == id);

      return product;
    }

    [HttpGet("categories/{id:int}")]
    public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id)
    {
      var products = await context.Products
      .Include(x => x.Category)
      .AsNoTracking()
      .Where(x => x.CategoryId == id)
      .ToListAsync();

      return products;
    }

    [HttpPost("")]
    public async Task<ActionResult<Product>> Post(
        [FromServices] DataContext context,
        [FromBody] Product model
    )
    {
      if (ModelState.IsValid)
      {
        context.Products.Add(model);
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