using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IBodyStyleRepository
    {
        List<BodyStyle> GetBodyStyles();
        BodyStyle GetBodyStyleById(int? id);
        
    }
}
