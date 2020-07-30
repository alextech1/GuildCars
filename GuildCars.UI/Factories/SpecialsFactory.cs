using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.UI.Mockup;
using GuildCars.UI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Factories
{
    public static class SpecialsFactory
    {
        public static ISpecialsRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new SpecialsRepositoryMock();
                case "ADO":
                    return new SpecialsRepositoryADO();
                case "EF":
                    return new SpecialsRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}