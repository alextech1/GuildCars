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
    public static class PurchaseTypeFactory
    {
        public static IPurchaseTypeRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new PurchaseTypeRepositoryMock();
                case "ADO":
                    return new PurchaseTypeRepositoryADO();
                case "EF":
                    return new PurchaseTypeRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}