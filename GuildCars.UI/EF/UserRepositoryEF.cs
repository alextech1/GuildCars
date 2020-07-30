using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public UserRepositoryEF() 
        {
            _context = new ApplicationDbContext();
        }

        public User GetApplicationById(string id)
        {
            var applicationUser = _context.Users.Find(id);

            User myUser = new User
            {
                Id = applicationUser.Id,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.Email,
                RoleID = applicationUser.RoleID,
                UserName = applicationUser.UserName
            };

            return myUser;
        }

        public List<User> GetUsers()
        {
            var myUsers = _context.Users.ToList();
            List<User> allUsers;

            allUsers = myUsers.Select(x => new User
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                RoleID = x.RoleID,
                UserName = x.UserName
            }).ToList();

            return allUsers;
        }

        public void InsertApplicationUser(User user)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                RoleID = user.RoleID,
                UserName = user.UserName
            };

            _context.Users.Add(applicationUser);
            _context.SaveChanges();
        }
    }
}