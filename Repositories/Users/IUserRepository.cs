using System.Collections.Generic;
using System.Threading.Tasks;
using asptest.Models;
using Microsoft.AspNetCore.Mvc;

namespace asptest.Repositories.Users
{
  public interface IUserRepository
  {
    void Save(User user);
    Task<ActionResult<List<User>>> Read();
  }
}