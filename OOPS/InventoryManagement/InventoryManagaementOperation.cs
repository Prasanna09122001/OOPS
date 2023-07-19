using Newtonsoft.Json;
using OOPS.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OOPS.InventoryManagement
{
    internal class InventoryManagementOperation
    {
        InventoryManagementDetails list;
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            list = JsonConvert.DeserializeObject<InventoryManagementDetails>(json);

            Display(list.Ricelist);
            Display(list.Wheatlist);
            Display(list.Pulseslist);
        }
        public void AddInventoryManagement(string objectName)
        {
            if (objectName.ToLower().Equals("rice"))
            {
                InventoryData data = new InventoryData()
                {
                    Name = Console.ReadLine(),
                    Weight = Convert.ToInt32(Console.ReadLine()),
                    PricePerKg = Convert.ToInt32(Console.ReadLine()),
                };
                list.Ricelist.Add(data);
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                InventoryData data = new InventoryData()
                {
                    Name = Console.ReadLine(),
                    Weight = Convert.ToInt32(Console.ReadLine()),
                    PricePerKg = Convert.ToInt32(Console.ReadLine()),
                };
                list.Wheatlist.Add(data);
            }
            if (objectName.ToLower().Equals("pulses"))
            {
                InventoryData data = new InventoryData()
                {
                    Name = Console.ReadLine(),
                    Weight = Convert.ToInt32(Console.ReadLine()),
                    PricePerKg = Convert.ToInt32(Console.ReadLine()),
                };
                list.Pulseslist.Add(data);
            }
        }
        public void WriteToJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filepath, json);
        }
        public void Display(List<InventoryData> list)
        {
            foreach (var data in list)
            {
                Console.WriteLine(data.Name + " " + data.Weight + " " + data.PricePerKg);
            }
        }

    }
}