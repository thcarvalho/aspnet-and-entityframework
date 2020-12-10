using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asptest.Models;
using asptest.Data;
using Microsoft.EntityFrameworkCore;
using asptest.Repositories.Products;

namespace asptest.Controllers
{
  [Route("v1/products")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    [HttpGet("")]
    public async Task<ActionResult<List<Product>>> Get(
      [FromServices] DataContext context,
      [FromServices] IProductRepository productRepository)
    {
      var products = await productRepository.List();
      return products;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(
      [FromServices] DataContext context,
      [FromServices] IProductRepository productRepository,
      int id)
    {
      var product = await productRepository.Read(id);
      return product;
    }

    [HttpGet("categories/{id:int}")]
    public async Task<ActionResult<List<Product>>> GetByCategory(
      [FromServices] DataContext context, 
      [FromServices] IProductRepository productRepository,
      int id)
    {
      var products = await productRepository.ListByCategory(id);
      return products;      
    }

    [HttpPost("")]
    public async Task<ActionResult<Product>> Post(
        [FromServices] DataContext context,
        [FromServices] IProductRepository productRepository,
        [FromBody] Product model
    )
    {
      if (ModelState.IsValid)
      {
        productRepository.Save(model);
        return model;
      }
      else
      {
        return BadRequest(ModelState);
      }
    }

  }
}