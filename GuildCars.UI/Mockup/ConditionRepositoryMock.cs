using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.UI.Mockup
{
    public class ConditionRepositoryMock : IConditionRepository
    {
        private static List<Condition> conditions = new List<Condition>
        {
            new Condition { ConditionID = 1, ConditionType = "New" },
            new Condition { ConditionID = 2, ConditionType = "Used"}
        };

        public Condition GetConditionById(int? id)
        {
            return conditions.FirstOrDefault(x => x.ConditionID == id);
        }

        public List<Condition> GetConditions()
        {
            return conditions;
        }

        public void InsertCondition(Condition condition)
        {
            throw new NotImplementedException();
        }
    }
}
