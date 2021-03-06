﻿using GuildCars.Data;
using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.UI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Factories
{
    public static class UserFactory
    {
        public static IUserRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                //case "Mockup":
                //    return new TransmissionRepositoryMock();
                case "ADO":
                    return new UserRepositoryADO();
                case "EF":
                    return new UserRepositoryEF();
                default:
                    throw new Exception("Could not find mode in configuration");
            }
        }
    }
}