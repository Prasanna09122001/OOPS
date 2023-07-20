using Newtonsoft.Json;
using OOPS.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.StockMarket
{
    internal class CompanyBlockOperation
    {
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            List<CompanyBlock> list = JsonConvert.DeserializeObject<List<CompanyBlock>>(json);
            foreach (var data in list)
            {
                Console.WriteLine(data.StockName + " " + data.NoOfShares + " " + data.SharePrice);
            }
        }
    }
}
