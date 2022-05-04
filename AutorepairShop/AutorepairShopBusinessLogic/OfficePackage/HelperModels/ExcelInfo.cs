using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutorepairShopContracts.ViewModels;
using System.Threading.Tasks;

namespace AutorepairShopBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {

        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportRepairComponentViewModel> RepairComponents { get; set; }

    }
}
