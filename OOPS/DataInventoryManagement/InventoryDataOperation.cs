using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs.DataInventoryManagement
{
    internal class InventoryDataOperation
    {
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            List<InventoryData> list = JsonConvert.DeserializeObject<List<InventoryData>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.Name + " " + data.Weight + " " + data.PricePerKg);
            }
        }
    }
}

