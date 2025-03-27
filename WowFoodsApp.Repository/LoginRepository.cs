using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WowFoods.Models;

namespace WowFoodsApp.Repository
{
    public class LoginRepository(AppDbContext context) : ILoginRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> LoginCheck(User login)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);
                return user != null;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex);
                throw;
            }
        }
    }
}
