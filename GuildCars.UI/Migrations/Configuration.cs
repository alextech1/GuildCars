namespace GuildCars.UI.Migrations
{
    using GuildCars.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCars.UI.Models.ApplicationDbContext context)
        {
            //AspNetRoles table
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
            }

            //AspNetUsers table
            if (!context.Users.Any(u => u.UserName == "admin@guildcars.com"))
            {
                var passwordHasher = new PasswordHasher();
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    FirstName = "Bob",
                    LastName = "Guild",
                    UserName = "admin@guildcars.com",
                    Email = "admin@guildcars.com",
                    PasswordHash = passwordHasher.HashPassword("Pa$$w0rd1"),
                    RoleID = 2 // User = 1, Admin = 2
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Administrator");
            }
        }
    }
}
