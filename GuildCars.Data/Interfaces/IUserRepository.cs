﻿using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetApplicationById(string id);
        void InsertApplicationUser(User user);
    }
}