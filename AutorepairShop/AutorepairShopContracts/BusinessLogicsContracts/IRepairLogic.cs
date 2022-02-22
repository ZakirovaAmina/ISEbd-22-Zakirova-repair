using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopContracts.BindingModels;
using AutorepairShopContracts.ViewModels;

namespace AutorepairShopContracts.BusinessLogicsContracts
{
    public interface IRepairLogic
    {
        List<RepairViewModel> Read(RepairBindingModel model);
        void CreateOrUpdate(RepairBindingModel model);
        void Delete(RepairBindingModel model);
    }
}
