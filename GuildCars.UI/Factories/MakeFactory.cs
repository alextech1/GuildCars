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
    public static class MakeFactory
    {
        public static IMakeRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new MakeRepositoryMock();
                case "ADO":
                    return new MakeRepositoryADO();
                case "EF":
                    return new MakeRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}