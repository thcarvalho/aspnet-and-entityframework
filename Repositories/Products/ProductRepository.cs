using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asptest.Data;
using asptest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asptest.Repositories.Products
{
  public class ProductRepository : IProductRepository
  {
    private readonly DataContext _context;
    public ProductRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<ActionResult<Product>> Read(int id)
    {
      var product = await _context.Products
        .Include(x => x.Category)
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);

      return product;
    }

    public async Task<ActionResult<List<Product>>> List()
    {
      var products = await _context.Products.Include(x => x.Category).ToListAsync();
      return products;
    }

    public async Task<ActionResult<List<Product>>> ListByCategory(int id)
    {
      var products = await _context.Products
        .Include(x => x.Category)
        .AsNoTracking()
        .Where(x => x.CategoryId == id)
        .ToListAsync();

      return products;
    }

    public async void Save(Product product)
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();
    }

  }
}