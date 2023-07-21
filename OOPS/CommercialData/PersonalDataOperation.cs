using Newtonsoft.Json;
using OOPS.DataInventoryManagement;
using OOPS.StockMarket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.CommercialData
{
    internal class PersonalDataOperation
    {
        List<PersonalData> list = new List<PersonalData>();
        List<CompanyBlock> list1 = new List<CompanyBlock>();
        public int amount=0;
        public void StockAmount(int amount)
        {
            this.amount = amount;
            Console.WriteLine("Amount you Have is " + this.amount);
        }
        public void ReadCustomerStock(string filePath)
        {
            var json = File.ReadAllText(filePath);
             list = JsonConvert.DeserializeObject<List<PersonalData>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.StockSymbol + " " + data.NoOfShare + " " + data.SharePrice);
            }
            Console.WriteLine("Amount you Have is " + this.amount);
        }
        public void ReadCompanyStock(string filePath)
        {
            var json1 = File.ReadAllText(filePath);
            list1 = JsonConvert.DeserializeObject<List<CompanyBlock>>(json1);
            foreach (var item in list1)
            {
                Console.WriteLine(item.StockName + " " + item.NoOfShares + " " + item.SharePrice);
            }
        }
        public void CustomerBuyStockFromCompany()
        {
            Console.WriteLine("Enter the stock Name to buy");
            string stockname = Console.ReadLine();
            Console.WriteLine("Enter No of shares");
            int shares = Convert.ToInt32(Console.ReadLine());
            CompanyBlock stock = new CompanyBlock();
            foreach (var item in list1)
            {
                if (item.StockName.Equals(stockname))
                {
                    stock = item;
                    if (item.NoOfShares >= shares && item.SharePrice * shares <= this.amount)
                    {
                        item.NoOfShares -= shares;
                        this.amount -= item.SharePrice * shares;
                    }
                    else
                    {
                        stock = null;
                    }
                }
            }
            if (stock == null)
                Console.WriteLine("You didn't have enough Amount");
            else
            {
                PersonalData buyCustomerstock = new PersonalData();
                foreach (var personalData in list)
                {
                    if (personalData.StockSymbol.Equals(stockname))
                    {
                        buyCustomerstock = personalData;
                        personalData.NoOfShare += shares;
                        buyCustomerstock = null;
                    }
                }
                if (buyCustomerstock != null && stock.SharePrice != 0)
                {
                    buyCustomerstock.StockSymbol = stockname;
                    buyCustomerstock.NoOfShare = shares;
                    buyCustomerstock.SharePrice = stock.SharePrice;
                    list.Add(buyCustomerstock);
                }
            }
        }
        public void CustomerSellStockFromCompany()
        {
            Console.WriteLine("Enter the stock Name to Sell");
            string stockname = Console.ReadLine();
            Console.WriteLine("Enter No of shares");
            int shares = Convert.ToInt32(Console.ReadLine());
            PersonalData sellCustomerstock = new PersonalData();
            foreach (var data in list)
            {
                if (data.StockSymbol.Equals(stockname))
                {
                    sellCustomerstock = data;
                    if (data.NoOfShare - shares >= 0)
                    {
                        data.NoOfShare -= shares;
                        this.amount += data.SharePrice * shares;
                    }
                    else
                    {
                        Console.WriteLine("You Dont have Any Shares");
                    }
                }
            }
            CompanyBlock stock = new CompanyBlock();
            foreach(var item in list1)
            {
                if(item.StockName.Equals(stockname))
                {
                    stock = item;
                }
            }
            stock.NoOfShares += shares;

        }
        public void WriteToCompanyFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(list1);
            File.WriteAllText(filepath, json);
        }
        public void WriteToCustomerFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filepath, json);
        }
    }
}
