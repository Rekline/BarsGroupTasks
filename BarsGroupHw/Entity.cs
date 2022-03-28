using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsGroupHw
{
    public class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }

        public static Dictionary<int, List<Entity>> ConvertToDictionary(List<Entity> listOfEnt)
        {
            var dict = new Dictionary<int, List<Entity>>();

            foreach (var ent in listOfEnt)
            {
                if (dict.ContainsKey(ent.ParentId))
                {
                    dict[ent.ParentId].Add(ent);
                }
                else
                {
                    dict.Add(ent.ParentId, new List<Entity>());
                    dict[ent.ParentId].Add(ent);
                }
            }

            return dict;
        }

        public static void EntityTest()
        {
            var entList = new List<Entity>
            {
                new() { Id = 1, ParentId = 0, Name = "Root entity" },
                new() { Id = 2, ParentId = 1, Name = "Child of 1 entity" },
                new() { Id = 3, ParentId = 1, Name = "Child of 1 entity" },
                new() { Id = 4, ParentId = 2, Name = "Child of 2 entity" },
                new() { Id = 5, ParentId = 4, Name = "Child of 4 entity" }
            };

            var entDict = ConvertToDictionary(entList);
            foreach(var (key, entities) in entDict)
            {
                foreach (var ent in entities)
                {
                    Console.WriteLine($"Key = {key}, Value = List {ent.Id}");
                }
            }

        }
    }
}
