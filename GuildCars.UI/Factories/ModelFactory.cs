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
    public static class ModelFactory
    {
        public static IModelRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new ModelRepositoryMock();
                case "ADO":
                    return new ModelRepositoryADO();
                case "EF":
                    return new ModelRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}