using OOPS.DataInventoryManagement;
using OOPS.InventoryManagement;
using OOPS.InventoryManagement;
using OOPS.StockMarket;
using System;
using System.Collections;
using System.Security.AccessControl;

namespace OOPS
{
    class program
    {
        static string inventory_filepath = @"D:\Bridgelabz Statement\OOPS\OOPS\OOPS\InventoryManagement\InventoryManagementData.json";
        static string inventory_filepath1 = @"D:\Bridgelabz Statement\OOPS\OOPS\OOPS\StockMarket\CompanyBlock.json";
        static void Main()
        {
            CompanyBlockOperation details1 = new CompanyBlockOperation();
            InventoryManagementOperation details = new InventoryManagementOperation();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter Which Program Has to be Executed\n1.Data Inventory Management\n2.Inventory Management");
                int Choice1 = Convert.ToInt32(Console.ReadLine());
                switch (Choice1)
                {
                    case 1:
                        details1.ReadInventoryJson(inventory_filepath1);
                        break;
                   case 2:
                        bool flag1 = true;
                        while (flag1)
                         {
                    Console.WriteLine("\nEnter the Part to be Exeuted\n1.Read The List\n2.Add the Name to the list\n3.Edit The Name in the list\n4.Delete the Name in the list");
                    int input = Convert.ToInt32(Console.ReadLine());
                           switch (input)
                           {
                        case 1:
                            details.ReadInventoryJson(inventory_filepath);
                            break;
                        case 2:
                            Console.WriteLine("\nWrite What crop Has been to added \nRice,Wheat(or)Pulses");
                            string crop = Console.ReadLine();
                            Console.WriteLine("Enter the Name,Weight and PriceperKg");
                            details.AddInventoryManagement(crop);
                            details.WriteToJsonFile(inventory_filepath);
                            break;
                        case 3:
                            Console.WriteLine("\nWrite What crop Has been to Edited \nRice,Wheat(or)Pulses");
                            string crop1 = Console.ReadLine();
                            Console.WriteLine("Enter the Name of the product");
                            string crop2 = Console.ReadLine();
                            details.EditInventoryManagement(crop1, crop2);
                            details.WriteToJsonFile(inventory_filepath);
                            break;
                        case 4:
                            Console.WriteLine("\nWrite What crop Has been to deleted \nRice,Wheat(or)Pulses");
                            string crop3 = Console.ReadLine();
                            Console.WriteLine("Enter the Name of the product");
                            string crop4 = Console.ReadLine();
                            details.DeleteInventoryManagement(crop3, crop4);
                            details.WriteToJsonFile(inventory_filepath);
                            break;
                        default:
                            flag1 = false;
                            break;
                             }
                        }
                break;
                }
            } 
        }
    }
}