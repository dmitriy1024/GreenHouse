using System;
using GreenHouse.Domain.Abstract;
using GreenHouse.Domain.Entities;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace GreenHouse.Domain.Concrete
{
    public class EFAspUserRepository : IAspUserRepository
    {
        private EFDbContext _context = new EFDbContext();

        public bool ChangeName(string userId, string name)
        {
            var users = _context.AspNetUsers.Where(a => String.Compare(a.Id, userId, false) == 0);
            if (users.Count() > 0)
            {
                var user = users.First();
                try
                {
                    user.UserName = name;
                    _context.SaveChanges();
                    return true;
                }
                catch (DbUpdateException e)
                {
                    System.Diagnostics.Debug.WriteLine("Exception " + e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ChangeNameAndLogin(string userId, string name, string email)
        {
            var users = _context.AspNetUsers.Where(a => String.Compare(a.Id, userId, false) == 0);
            if (users.Count() > 0)
            {
                var user = users.First();
                try
                {
                    user.Email = email;
                    user.UserName = name;
                    _context.SaveChanges();
                    return true;
                }
                catch(DbUpdateException e)
                {
                    System.Diagnostics.Debug.WriteLine("Exception " + e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

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

        public AspNetUser GetAspNetUserById(string id)
        {
            var users = _context.AspNetUsers.Where(a => String.Compare(a.Id, id, false) == 0);
            if (users.Count() > 0)
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
