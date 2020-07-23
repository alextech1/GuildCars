using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using GuildCars.Data.Factories;
using GuildCars.Models.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GuildCars.UI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }
    }

    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> //DbContext IdentityDbContext<ApplicationUser> IdentityDbContext 
    {        
        public ApplicationDbContext()
            : base("DefaultConnection") //, throwIfV1Schema: false
        {
            //Database.SetInitializer(new ApplicationDbInitializer());
        }

        //static ApplicationDbContext()
        //{
        //    Database.SetInitializer(new ApplicationDbInitializer());
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<PurchaseType> PurchaseTypes { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BodyStyle> BodyStyles { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<ExteriorColor> ExteriorColors { get; set; }
        public DbSet<InteriorColor> InteriorColors { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<GuildRole> GuildRoles { get; set; }
        public DbSet<Specials> Specials { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }

             

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
        }

        
    }

    //public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //{
        
    //}
}