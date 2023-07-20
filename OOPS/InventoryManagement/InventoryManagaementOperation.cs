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
using System.Xml.Linq;

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
            InventoryData details = new InventoryData()
            {
                Name = Console.ReadLine(),
                Weight = Convert.ToInt32(Console.ReadLine()),
                PricePerKg = Convert.ToInt32(Console.ReadLine()),
            };
            if (objectName.ToLower().Equals("rice"))
            {
                list.Ricelist.Add(details);
                Console.WriteLine("The Data is Added");
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                list.Wheatlist.Add(details);
                Console.WriteLine("The Data is Added");
            }
            if (objectName.ToLower().Equals("pulses"))
            {
                list.Pulseslist.Add(details);
                Console.WriteLine("The Data is Added");
            }
        }
        public void DeleteInventoryManagement(string objectName,string InventoryName)
        {
            InventoryData details = new InventoryData();
            if (objectName.ToLower().Equals("rice"))
            {
                foreach(var data in list.Ricelist)
                {
                    if (data.Name.Equals(InventoryName))
                        details = data;
                }
                if(details != null)
                    list.Ricelist.Remove(details);
                    Console.WriteLine("The Data is Removed");
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                foreach (var data in list.Wheatlist)
                {
                    if (data.Name.Equals(InventoryName))
                        details = data;
                }
                if (details != null)
                    list.Wheatlist.Remove(details);
                    Console.WriteLine("The Data is Removed");
            }
            if (objectName.ToLower().Equals("pulses"))
            {
                foreach (var data in list.Pulseslist)
                {
                    if (data.Name.Equals(InventoryName))
                        details = data;
                }
                if (details != null)
                    list.Pulseslist.Remove(details);
                    Console.WriteLine("The Data is Removed");
            }
            if (details == null)
                Console.WriteLine("No Inventory Details Exists");
        }

        public void EditInventoryManagement(string objectName, string InventoryName)
        {
            InventoryData details = new InventoryData();
            if (objectName.ToLower().Equals("rice"))
            {
                foreach (var data in list.Ricelist)
                {
                    if (data.Name.Equals(InventoryName))
                        details = data;
                }
                if (details != null)
                { 
                    Console.WriteLine("Write the Edited Ricename,Weight,Price per Kg");
                    string Name = Console.ReadLine();
                    int Weight = Convert.ToInt32(Console.ReadLine());
                    int PricePerKg = Convert.ToInt32(Console.ReadLine());
                    details.Name = Name;
                    details.Weight = Weight;
                    details.PricePerKg = PricePerKg;
                    Console.WriteLine("The Data is Edited");
                } 
            }
            if (objectName.ToLower().Equals("wheat"))
            {
                foreach (var data in list.Wheatlist)
                {
                    if (data.Name.Equals(InventoryName))
                        details = data;
                }
                if (details != null)
                {
                    Console.WriteLine("Write the Edited wheatname,Weight,Price per Kg");
                    string Name = Console.ReadLine();
                    int Weight = Convert.ToInt32(Console.ReadLine());
                    int PricePerKg = Convert.ToInt32(Console.ReadLine());
                    details.Name = Name;
                    details.Weight = Weight;
                    details.PricePerKg = PricePerKg;
                    Console.WriteLine("The Data is Edited");
                }
            }
            if (objectName.ToLower().Equals("pulses"))
            {
                foreach (var data in list.Pulseslist)
                {
                    if (data.Name.Equals(InventoryName))
                        details = data;
                }
                if (details != null)
                {
                    Console.WriteLine("Write the Edited Pulsesname,Weight,Price per Kg");
                    string Name = Console.ReadLine();
                    int Weight = Convert.ToInt32(Console.ReadLine());
                    int PricePerKg = Convert.ToInt32(Console.ReadLine());
                    details.Name = Name;
                    details.Weight = Weight;
                    details.PricePerKg = PricePerKg;
                    Console.WriteLine("The Data is Edited");
                }
            }
            if (details == null)
                Console.WriteLine("No Inventory Details Exists");
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