using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IExteriorColorRepository
    {
        List<ExteriorColor> GetExteriorColors();
        ExteriorColor GetExteriorColorById(int? id);
    }
}
