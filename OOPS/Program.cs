using OOPs.DataInventoryManagement;
using System;
namespace OOPs
{
    class program
    {
        static string inventory_filepath = @"D:\Bridgelabz Statement\OOPS\OOPS\OOPS\DataInventoryManagement\InventoryData.json";
        static void Main()
        {
            InventoryDataOperation details = new InventoryDataOperation();
            details.ReadInventoryJson(inventory_filepath);
        }
    }
}