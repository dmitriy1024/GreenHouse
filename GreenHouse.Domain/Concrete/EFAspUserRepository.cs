using System;
using GreenHouse.Domain.Abstract;
using GreenHouse.Domain.Entities;
using System.Linq;

namespace GreenHouse.Domain.Concrete
{
    public class EFAspUserRepository : IAspUserRepository
    {
        private EFDbContext _context = new EFDbContext();

        public AspNetUser GetAspNetUserByEmail(string email)
        {
            var users = _context.AspNetUsers.Where(a => String.Compare(a.Email, email, true) == 0);
            if(users.Count() > 0)
            {
                return users.First();
            }
            else
            {
                return null;
            }
        }
    }
}
