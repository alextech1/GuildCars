using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Mockup;
using GuildCars.Models.Entity;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using GuildCars.Data;

namespace GuildCars.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public AdminController() { }

        public ActionResult Used()
        {
            CarViewModel carViewModel = new CarViewModel();

            var carRepo = GuildRepositoryFactory.GetRepository();

            List<Car> carList = carRepo.GetAllCars();

            List<CarViewModel> carVMList = carList.Select(x => new CarViewModel
            {
                CarID = x.CarID,
                Year = x.Year,
                MakeName = x.Make.MakeName,
                ModelName = x.Model.ModelName,
                BodyStyleName = x.BodyStyle.BodyStyleName,
                TransmissionType = x.Transmission.TransmissionType,
                ExteriorColorName = x.ExteriorColor.Color,
                InteriorColorName = x.InteriorColor.Color,
                Mileage = x.Mileage,
                VIN = x.VIN,
                SalePrice = x.SalePrice,
                MSRP = x.MSRP,
                ImageFileName = x.Photo
            }).ToList();

            return View(carVMList);
        }

        public ActionResult New()
        {
            CarViewModel carViewModel = new CarViewModel();

            carViewModel.IGuildRepository = GuildRepositoryFactory.GetRepository();

            carViewModel.Cars = carViewModel.IGuildRepository.GetAllCars();

            var carList = carViewModel.Cars;

            List<CarViewModel> carVMList = carList.Select(x => new CarViewModel
            {
                CarID = x.CarID,
                Year = x.Year,
                MakeName = x.Make.MakeName,
                ModelName = x.Model.ModelName,
                BodyStyleName = x.BodyStyle.BodyStyleName,
                TransmissionType = x.Transmission.TransmissionType,
                ExteriorColorName = x.ExteriorColor.Color,
                InteriorColorName = x.InteriorColor.Color,
                Mileage = x.Mileage,
                VIN = x.VIN,
                SalePrice = x.SalePrice,
                MSRP = x.MSRP,
                ImageFileName = x.Photo
            }).ToList();

            return View(carVMList);
        }

        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            CarViewModel carViewModel = new CarViewModel();

            carViewModel.IGuildRepository = GuildRepositoryFactory.GetRepository();

            var carvm = carViewModel.IGuildRepository.GetCarById(id);

            carViewModel.CarID = carvm.CarID;
            carViewModel.Year = carvm.Year;
            carViewModel.MakeName = carvm.Make.MakeName;
            carViewModel.ModelName = carvm.Model.ModelName;
            carViewModel.BodyStyleName = carvm.BodyStyle.BodyStyleName;
            carViewModel.TransmissionType = carvm.Transmission.TransmissionType;
            carViewModel.ExteriorColorName = carvm.ExteriorColor.Color;
            carViewModel.InteriorColorName = carvm.InteriorColor.Color;
            carViewModel.Mileage = carvm.Mileage;
            carViewModel.VIN = carvm.VIN;
            carViewModel.SalePrice = carvm.SalePrice;
            carViewModel.MSRP = carvm.MSRP;
            carViewModel.ImageFileName = carvm.Photo;
            carViewModel.Description = carvm.Description;

            return View(carViewModel);
        }

        [Authorize]
        public ActionResult Add()
        {
            var model = new CarAddViewModel();

            var carRepo = GuildRepositoryFactory.GetRepository();
            var makesRepo = MakeFactory.GetRepository();
            var modelRepo = ModelFactory.GetRepository();
            var typesRepo = ConditionFactory.GetRepository();
            var bodyStylesRepo = BodyStyleFactory.GetRepository();
            var transmissionsRepo = TransmissionFactory.GetRepository();
            var extColorsRepo = ExteriorColorFactory.GetRepository();
            var intColorsRepo = InteriorColorFactory.GetRepository();

            CarAddViewModel viewModel = new CarAddViewModel
            {
                Makes = makesRepo.GetMakes(),
                Models = modelRepo.GetModels(),
                Types = typesRepo.GetConditions(),
                BodyStyles = bodyStylesRepo.GetBodyStyles(),
                Transmissions = transmissionsRepo.GetTransmissions(),
                ExteriorColors = extColorsRepo.GetExteriorColors(),
                InteriorColors = intColorsRepo.GetInteriorColors()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(CarAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var carRepo = GuildRepositoryFactory.GetRepository();
                var makesRepo = MakeFactory.GetRepository();
                var modelRepo = ModelFactory.GetRepository();
                var typesRepo = ConditionFactory.GetRepository();
                var bodyStylesRepo = BodyStyleFactory.GetRepository();
                var transmissionsRepo = TransmissionFactory.GetRepository();
                var extColorsRepo = ExteriorColorFactory.GetRepository();
                var intColorsRepo = InteriorColorFactory.GetRepository();

                try
                {
                    model.Car.UserID = AuthorizeUtilities.GetUserId(this);

                    model.Car.BodyStyle = new BodyStyle();
                    model.Car.BodyStyle.BodyStyleID = model.Car.BodyStyleID;
                    model.Car.BodyStyle.BodyStyleName = bodyStylesRepo.GetBodyStyleById(model.Car.BodyStyleID).BodyStyleName;
                    model.Car.Condition = new Condition();
                    model.Car.Condition.ConditionID = model.Car.ConditionID;
                    model.Car.Condition.ConditionType = typesRepo.GetConditionById(model.Car.ConditionID).ConditionType;
                    model.Car.ExteriorColor = new ExteriorColor();
                    model.Car.ExteriorColor.ExteriorColorID = model.Car.ExteriorColorID;
                    model.Car.ExteriorColor.Color = extColorsRepo.GetExteriorColorById(model.Car.ExteriorColorID).Color;
                    model.Car.InteriorColor = new InteriorColor();
                    model.Car.InteriorColor.InteriorColorID = model.Car.InteriorColorID;
                    model.Car.InteriorColor.Color = intColorsRepo.GetInteriorColorById(model.Car.InteriorColorID).Color;
                    model.Car.Make = new Make();
                    model.Car.Make.MakeID = model.Car.MakeID;
                    model.Car.Make.MakeName = makesRepo.GetMakeById(model.Car.MakeID).MakeName;
                    model.Car.Make.DateAdded = DateTime.Now.ToString("MM/dd/yyyy");
                    model.Car.Make.UserID = model.Car.UserID;
                    model.Car.Model = new Model();
                    model.Car.Model.ModelID = model.Car.ModelID;
                    model.Car.Model.MakeID = model.Car.MakeID;
                    model.Car.Model.ModelName = modelRepo.GetModelById(model.Car.ModelID).ModelName;
                    model.Car.Model.DateAdded = DateTime.Now.ToString("MM/dd/yyyy");
                    model.Car.Model.UserID = model.Car.UserID;
                    model.Car.DateAdded = DateTime.Now.ToString("MM/dd/yyyy");
                    model.Car.Transmission = new Transmission();
                    model.Car.Transmission.TransmissionID = model.Car.TransmissionID;
                    model.Car.Transmission.TransmissionType = transmissionsRepo.GetTransmissionById(model.Car.TransmissionID).TransmissionType;
                    

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        /*int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }*/

                        model.ImageUpload.SaveAs(filePath);
                        model.Car.Photo = Path.GetFileName(filePath);
                    }

                    carRepo.InsertCar(model.Car);
                    bodyStylesRepo.InsertBodyStyle(model.Car.BodyStyle);
                    typesRepo.InsertCondition(model.Car.Condition);
                    extColorsRepo.InsertExteriorColor(model.Car.ExteriorColor);
                    intColorsRepo.InsertInteriorColor(model.Car.InteriorColor);
                    makesRepo.InsertMake(model.Car.Make);
                    modelRepo.InsertModel(model.Car.Model);
                    transmissionsRepo.InsertTransmission(model.Car.Transmission);

                    if (Settings.GetRepositoryType() == "EF")
                    {
                        _context.Cars.Add(model.Car);

                        if (model.Car == null)
                            model.Car = new Car();

                        _context.SaveChanges();
                    }

                    

                    
                    return RedirectToAction("Vehicles");
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            else
                return View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = new CarEditViewModel();

            var carRepo = GuildRepositoryFactory.GetRepository();
            var makesRepo = MakeFactory.GetRepository();
            var modelRepo = ModelFactory.GetRepository();
            var typesRepo = ConditionFactory.GetRepository();
            var bodyStylesRepo = BodyStyleFactory.GetRepository();
            var transmissionsRepo = TransmissionFactory.GetRepository();
            var extColorsRepo = ExteriorColorFactory.GetRepository();
            var intColorsRepo = InteriorColorFactory.GetRepository();

            if (model.Car.UserID != AuthorizeUtilities.GetUserId(this))
            {
                throw new Exception("You are not logged in.");
            }

            CarEditViewModel viewModel = new CarEditViewModel
            {
                Car = carRepo.GetCarById(id),
                Makes = makesRepo.GetMakes(),
                MakesID = model.Car.Make.MakeID,
                Models = modelRepo.GetModels(),
                ModelsID = model.Car.Model.ModelID,
                Types = typesRepo.GetConditions(),
                TypesID = model.Car.Condition.ConditionID,
                BodyStyles = bodyStylesRepo.GetBodyStyles(),
                BodyStylesID = model.Car.BodyStyle.BodyStyleID,
                Transmissions = transmissionsRepo.GetTransmissions(),
                TransmissionsID = model.Car.Transmission.TransmissionID,
                ExteriorColors = extColorsRepo.GetExteriorColors(),
                ExteriorColorsID = model.Car.ExteriorColor.ExteriorColorID,
                InteriorColors = intColorsRepo.GetInteriorColors(),
                InteriorColorsID = model.Car.InteriorColor.InteriorColorID,
                Year = model.Car.Year,
                Mileage = model.Car.Mileage,
                VIN = model.Car.VIN,
                MSRP = model.Car.MSRP,
                SalePrice = model.Car.SalePrice,
                Description = model.Car.Description,
                ImageFileName = model.Car.Photo
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(CarEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var carRepo = GuildRepositoryFactory.GetRepository();

                carRepo.UpdateCar(model.Car);

                return RedirectToAction("Vehicles");
            }
            else
            {
                return View(model.Car);
            }

        }

        public ActionResult Specials()
        {
            var model = new SpecialsViewModel();

            var specialsRepo = SpecialsFactory.GetRepository();

            model.SpecialsList = specialsRepo.GetSpecials();

            List<SpecialsViewModel> viewModel = model.SpecialsList.Select(x => new SpecialsViewModel
            {
                SpecialsID = x.SpecialsID,
                Title = x.Title,
                Description = x.Description,
                ImageFileName = x.ImageFileName
            }).ToList();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Specials(SpecialsViewModel specialsVM)
        {
            if (ModelState.IsValid)
            {
                var specialsRepo = SpecialsFactory.GetRepository();

                specialsRepo.AddSpecial(specialsVM.Specials);

                specialsVM.SpecialsList = specialsRepo.GetSpecials();

                List<SpecialsViewModel> viewModel = specialsVM.SpecialsList.Select(x => new SpecialsViewModel
                {
                    SpecialsID = x.SpecialsID,
                    Title = x.Title,
                    Description = x.Description,
                    ImageFileName = x.ImageFileName
                }).ToList();

                return View(specialsVM);
            }
            else
            {
                return View(specialsVM);
            }
        }

        public ActionResult DeleteSpecial(int id)
        {
            var specialsRepo = SpecialsFactory.GetRepository();

            specialsRepo.RemoveSpecial(id);

            return RedirectToAction("Specials");
        }

        public ActionResult Users()
        {
            var rolesRepo = RoleFactory.GetRepository();
            var allUsers = _context.Users.ToList();
            var users = allUsers.Where(x => x.RoleID == 1).ToList();
            var userVM = users.Select(user => new UserViewModel
            {
                UserID = user.Id,
                Email = user.Email,
                Role = rolesRepo.GetRoleById(user.RoleID).RoleName,
                FirstName = user.FirstName,
                LastName = user.LastName
            }).ToList();

            var admins = allUsers.Where(x => x.RoleID == 2).ToList();
            var adminsVM = admins.Select(user => new UserViewModel
            {
                UserID = user.Id,
                Email = user.Email,
                Role = rolesRepo.GetRoleById(user.RoleID).RoleName,
                FirstName = user.FirstName,
                LastName = user.LastName
            }).ToList();
            var model = new GroupedUserViewModel { Users = userVM, Admins = adminsVM };

            return View(model);
        }

        [Authorize]
        public ActionResult Makes()
        {
            var allUsers = _context.Users.ToList();
            var allMakes = _context.Makes.ToList();

            var model = new MakesViewModel();

            var makesRepo = MakeFactory.GetRepository();

            model.Makes = makesRepo.GetMakes();
            model.MakesVM = new List<MakesViewModel>();

            model.MakesVM = allMakes.Select(x => new MakesViewModel
            {
                MakeName = x.MakeName,
                DateAdded = x.DateAdded,
                User = allUsers.Where(y => y.Id == x.UserID).Select(y => y.Email).FirstOrDefault()
            }).ToList();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Makes(MakesViewModel makes)
        {
            if (ModelState.IsValid)
            {
                var makesRepo = MakeFactory.GetRepository();

                makes.Make.UserID = AuthorizeUtilities.GetUserId(this);
                makes.Make.DateAdded = DateTime.Now.ToString("MM/dd/yyyy");
                makesRepo.InsertMake(makes.Make);

                var allUsers = _context.Users.ToList();
                var allMakes = _context.Makes.ToList();

                makes.Makes = makesRepo.GetMakes();
                makes.MakesVM = new List<MakesViewModel>();

                makes.MakesVM = allMakes.Select(x => new MakesViewModel
                {
                    MakeName = x.MakeName,
                    DateAdded = x.DateAdded,
                    User = allUsers.Where(y => y.Id == x.UserID).Select(y => y.Email).FirstOrDefault()
                }).ToList();

                return View(makes);
            }
            else
            {
                return View(makes);
            }
        }

        [Authorize]
        public ActionResult Models()
        {
            var allUsers = _context.Users.ToList();
            var allMakes = _context.Makes.ToList();
            var allModels = _context.Models.ToList();

            var model = new ModelsViewModel();

            var modelsRepo = ModelFactory.GetRepository();
            var makesRepo = MakeFactory.GetRepository();            

            List<ModelsViewModel> modelList = allModels.Select(x => new ModelsViewModel
            {
                MakeName = allMakes.Where(y => y.MakeID == x.MakeID).Select(y => y.MakeName).FirstOrDefault(),
                ModelName = x.ModelName,
                DateAdded = x.DateAdded,
                User = allUsers.Where(y => y.Id == x.UserID).Select(y => y.Email).FirstOrDefault()
            }).ToList();


            ModelsViewModel viewModel = new ModelsViewModel
            {
                Makes = makesRepo.GetMakes(),
                ModelsVM = modelList
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Models(ModelsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelsRepo = ModelFactory.GetRepository();
                var makesRepo = MakeFactory.GetRepository();

                model.Model = new Model();
                model.Model.Make.MakeID = model.Make.MakeID;
                model.Model.Make.MakeName = makesRepo.GetMakeById(model.Make.MakeID).MakeName;
                model.Model.UserID = AuthorizeUtilities.GetUserId(this);
                model.Model.DateAdded = DateTime.Now.ToString("MM/dd/yyyy");
                modelsRepo.InsertModel(model.Model);

                var allUsers = _context.Users.ToList();
                var allMakes = _context.Makes.ToList();
                var allModels = _context.Models.ToList();

                model.Models = modelsRepo.GetModels();
                model.ModelsVM = new List<ModelsViewModel>();

                model.ModelsVM = allModels.Select(x => new ModelsViewModel
                {
                    MakeName = allMakes.Where(y => y.MakeID == x.MakeID).Select(y => y.MakeName).FirstOrDefault(),
                    ModelName = x.ModelName,
                    DateAdded = x.DateAdded,
                    User = allUsers.Where(y => y.Id == x.UserID).Select(y => y.Email).FirstOrDefault()
                }).ToList();

                return View(model);
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult EditUser(string id)
        {
            var rolesRepo = RoleFactory.GetRepository();
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var appUser = userMgr.FindById(id);

            var user = new UserEditViewModel
            {
                UserID = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email,
                Roles = rolesRepo.GetRoles(),
                RolesID = appUser.RoleID
            };

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(store);

            var currentUser = manager.FindById(model.UserID);
            currentUser.Id = model.UserID;
            currentUser.FirstName = model.FirstName;
            currentUser.LastName = model.LastName;
            currentUser.Email = model.Email;
            currentUser.RoleID = model.Role.RoleID;

            await manager.RemovePasswordAsync(model.UserID);
            await manager.AddPasswordAsync(model.UserID, model.Password);

            await manager.UpdateAsync(currentUser);
            var contx = store.Context;
            contx.SaveChanges();
            return RedirectToAction("Users");
        }
    }
}
