using Newtonsoft.Json;
using OOPS.CommercialData;
using OOPS.DataInventoryManagement;
using OOPS.InventoryManagement;
using OOPS.InventoryManagement;
using OOPS.StockMarket;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace OOPS
{
    class program
    {
        static string inventory_filepath = @"D:\Bridgelabz Statement\OOPS\OOPS\OOPS\DataInventoryManagement\InventoryData.json";
        static string inventory_filepath1 = @"D:\Bridgelabz Statement\OOPS\OOPS\OOPS\InventoryManagement\InventoryManagementData.json";
        static string inventory_filepath2 = @"D:\Bridgelabz Statement\OOPS\OOPS\OOPS\StockMarket\CompanyBlock.json";
        static string inventory_filepath3 = @"D:\Bridgelabz Statement\OOPS\OOPS\OOPS\CommercialData\PersonalData.json";
        static void Main()
        {
            InventoryDataOperation details = new InventoryDataOperation();
            CompanyBlockOperation details2 = new CompanyBlockOperation();
            InventoryManagementOperation details1 = new InventoryManagementOperation();
            PersonalDataOperation details3 = new PersonalDataOperation();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter Which Program Has to be Executed\n1.Data Inventory Management\n2.Inventory Management\n3.Stock Market\n4.Commercial Data");
                int Choice1 = Convert.ToInt32(Console.ReadLine());
                switch (Choice1)
                {
                    case 1:
                        details.ReadInventoryJson(inventory_filepath);
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
                                    details1.ReadInventoryJson(inventory_filepath1);
                                    break;
                                case 2:
                                    Console.WriteLine("\nWrite What crop Has been to added \nRice,Wheat(or)Pulses");
                                    string crop = Console.ReadLine();
                                    Console.WriteLine("Enter the Name,Weight and PriceperKg");
                                    details1.AddInventoryManagement(crop);
                                    details1.WriteToJsonFile(inventory_filepath1);
                                    break;
                                case 3:
                                    Console.WriteLine("\nWrite What crop Has been to Edited \nRice,Wheat(or)Pulses");
                                    string crop1 = Console.ReadLine();
                                    Console.WriteLine("Enter the Name of the product");
                                    string crop2 = Console.ReadLine();
                                    details1.EditInventoryManagement(crop1, crop2);
                                    details1.WriteToJsonFile(inventory_filepath1);
                                    break;
                                case 4:
                                    Console.WriteLine("\nWrite What crop Has been to deleted \nRice,Wheat(or)Pulses");
                                    string crop3 = Console.ReadLine();
                                    Console.WriteLine("Enter the Name of the product");
                                    string crop4 = Console.ReadLine();
                                    details1.DeleteInventoryManagement(crop3, crop4);
                                    details1.WriteToJsonFile(inventory_filepath1);
                                    break;
                                default:
                                    flag1 = false;
                                    break;
                            }
                        }

                        break;
                    case 3:
                        details2.ReadInventoryJson(inventory_filepath2);
                        break;
                    case 4:
                        bool flag2 = true;
                        while (flag2)
                        {
                            Console.WriteLine("Enter the program to be Executed\n1.Read The Details\n2.Enter the Amount\n3.Buy stocks\n4.Sell Stocks\n5.Exit");
                            int input1 = Convert.ToInt32(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    Console.WriteLine("\nCompanyShares");
                                    details3.ReadCompanyStock(inventory_filepath2);
                                    Console.WriteLine("\nPersonalShares");
                                    details3.ReadCustomerStock(inventory_filepath3);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the Amount you have");
                                    int amount = Convert.ToInt32(Console.ReadLine());
                                    details3.StockAmount(amount);
                                    break;
                                case 3:
                                    details3.CustomerBuyStockFromCompany();
                                    details3.WriteToCompanyFile(inventory_filepath2);
                                    details3.WriteToCustomerFile(inventory_filepath3);
                                    break;
                                case 4:
                                    details3.CustomerSellStockFromCompany();
                                    details3.WriteToCustomerFile(inventory_filepath3);
                                    details3.WriteToCompanyFile(inventory_filepath2);
                                    break;
                                case 5:
                                    flag2 = false;
                                    break;
                            }
                        }
                        break;
                }
            } 
        }
      
    }
}