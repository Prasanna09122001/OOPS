using OOPS.DataInventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.InventoryManagement
{
    internal class InventoryManagementDetails
    {
        public List<InventoryData> Ricelist { get; set; }
        public List<InventoryData> Wheatlist { get; set; }
        public List<InventoryData> Pulseslist { get; set; }
    }
}