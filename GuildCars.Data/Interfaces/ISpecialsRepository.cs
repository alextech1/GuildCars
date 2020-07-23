using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialsRepository
    {
        List<Specials> GetSpecials();
        Specials GetSpecialsById(int? id);
        void AddSpecial(Specials specials);
        void Update(Specials specials);
        void RemoveSpecial(int? id);
    }
}
