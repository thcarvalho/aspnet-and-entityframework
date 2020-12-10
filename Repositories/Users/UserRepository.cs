using System.Collections.Generic;
using System.Threading.Tasks;
using asptest.Data;
using asptest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asptest.Repositories.Users
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
      _context = context;
    }

    public async void Save(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
    }
    public async Task<ActionResult<List<User>>> Read()
    {
      var users = await _context.Users.ToListAsync();
      foreach (var user in users)
      {
        user.Password = "";
      }
      return users;
    }
  }
}