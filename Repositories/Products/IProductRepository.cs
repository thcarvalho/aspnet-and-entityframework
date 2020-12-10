using System.Collections.Generic;
using System.Threading.Tasks;
using asptest.Models;
using Microsoft.AspNetCore.Mvc;

namespace asptest.Repositories.Products
{
  public interface IProductRepository
  {
    void Save(Product product);
    Task<ActionResult<Product>> Read(int id);
    Task<ActionResult<List<Product>>> List();
    Task<ActionResult<List<Product>>> ListByCategory(int id);

  }
}