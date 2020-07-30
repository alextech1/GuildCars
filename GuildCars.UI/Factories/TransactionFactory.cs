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
    public static class TransactionFactory
    {
        public static ITransactionRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Mockup":
                    return new TransactionRepositoryMock();
                case "ADO":
                    return new TransactionRepositoryADO();
                case "EF":
                    return new TransactionRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}