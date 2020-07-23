namespace GuildCars.UI.Migrations
{
    using GuildCars.Data.Factories;
    using GuildCars.Data.Mockup;
    using GuildCars.Models.Entity;
    using GuildCars.UI.Models;
    using Microsoft.Ajax.Utilities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
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

            if(context.States.Count() == 0)
            {
                var statesRepo = StateFactory.GetRepository();

                IList<State> statesToAdd = new List<State>();

                foreach (var state in statesRepo.GetStates())
                {
                    statesToAdd.Add(state);
                }

                context.States.AddRange(statesToAdd);

                base.Seed(context);
            }

            if (context.Makes.Count() == 0)
            {
                var makesRepo = MakeFactory.GetRepository();

                IList<Make> makesToAdd = new List<Make>();

                foreach (var make in makesRepo.GetMakes())
                {
                    makesToAdd.Add(make);
                }

                context.Makes.AddRange(makesToAdd);

                base.Seed(context);
            }

            if (context.Models.Count() == 0)
            {
                var modelsRepo = ModelFactory.GetRepository();

                IList<Model> modelsToAdd = new List<Model>();

                foreach (var model in modelsRepo.GetModels())
                {
                    modelsToAdd.Add(model);
                }

                context.Models.AddRange(modelsToAdd);

                base.Seed(context);
            }

            if (context.BodyStyles.Count() == 0)
            {
                var bodyStylesRepo = BodyStyleFactory.GetRepository();

                IList<BodyStyle> bodyStylesToAdd = new List<BodyStyle>();

                foreach (var bodyStyle in bodyStylesRepo.GetBodyStyles())
                {
                    bodyStylesToAdd.Add(bodyStyle);
                }

                context.BodyStyles.AddRange(bodyStylesToAdd);

                base.Seed(context);
            }

            if (context.Conditions.Count() == 0)
            {
                var conditionsRepo = ConditionFactory.GetRepository();

                IList<Condition> conditionsToAdd = new List<Condition>();

                foreach (var condition in conditionsRepo.GetConditions())
                {
                    conditionsToAdd.Add(condition);
                }

                context.Conditions.AddRange(conditionsToAdd);

                base.Seed(context);
            }

            if (context.ExteriorColors.Count() == 0)
            {
                var extColorsRepo = ExteriorColorFactory.GetRepository();

                IList<ExteriorColor> extColorsToAdd = new List<ExteriorColor>();

                foreach (var extColor in extColorsRepo.GetExteriorColors())
                {
                    extColorsToAdd.Add(extColor);
                }

                context.ExteriorColors.AddRange(extColorsToAdd);

                base.Seed(context);
            }

            if (context.ExteriorColors.Count() == 0)
            {
                var extColorsRepo = ExteriorColorFactory.GetRepository();

                IList<ExteriorColor> extColorsToAdd = new List<ExteriorColor>();

                foreach (var extColor in extColorsRepo.GetExteriorColors())
                {
                    extColorsToAdd.Add(extColor);
                }

                context.ExteriorColors.AddRange(extColorsToAdd);

                base.Seed(context);
            }

            if (context.InteriorColors.Count() == 0)
            {
                var intColorsRepo = InteriorColorFactory.GetRepository();

                IList<InteriorColor> intColorsToAdd = new List<InteriorColor>();

                foreach (var intColor in intColorsRepo.GetInteriorColors())
                {
                    intColorsToAdd.Add(intColor);
                }

                context.InteriorColors.AddRange(intColorsToAdd);

                base.Seed(context);
            }

            if (context.PurchaseTypes.Count() == 0)
            {
                var purchaseTypesRepo = PurchaseTypeFactory.GetRepository();

                IList<PurchaseType> purchaseTypesToAdd = new List<PurchaseType>();

                foreach (var purchaseType in purchaseTypesRepo.GetPurchaseTypes())
                {
                    purchaseTypesToAdd.Add(purchaseType);
                }

                context.PurchaseTypes.AddRange(purchaseTypesToAdd);

                base.Seed(context);
            }

            if (context.Specials.Count() == 0)
            {
                var specialsRepo = SpecialsFactory.GetRepository();

                IList<Specials> specialsToAdd = new List<Specials>();

                foreach (var special in specialsRepo.GetSpecials())
                {
                    specialsToAdd.Add(special);
                }

                context.Specials.AddRange(specialsToAdd);

                base.Seed(context);
            }

            if (context.Transmissions.Count() == 0)
            {
                var transmissionsRepo = TransmissionFactory.GetRepository();

                IList<Transmission> transmissionsToAdd = new List<Transmission>();

                foreach (var special in transmissionsRepo.GetTransmissions())
                {
                    transmissionsToAdd.Add(special);
                }

                context.Transmissions.AddRange(transmissionsToAdd);

                base.Seed(context);
            }

            if (context.Cars.Count() == 0)
            {
                var carsRepo = GuildRepositoryFactory.GetRepository();

                IList<Car> carsToAdd = new List<Car>();

                foreach (var car in carsRepo.GetAllCars())
                {
                    carsToAdd.Add(car);
                }

                context.Cars.AddRange(carsToAdd);

                base.Seed(context);
            }

            if (context.GuildRoles.Count() == 0)
            {
                var rolesRepo = RoleFactory.GetRepository();

                IList<GuildRole> rolesToAdd = new List<GuildRole>();

                foreach (var role in rolesRepo.GetRoles())
                {
                    rolesToAdd.Add(role);
                }

                context.GuildRoles.AddRange(rolesToAdd);

                base.Seed(context);
            }
        }
    }
}
