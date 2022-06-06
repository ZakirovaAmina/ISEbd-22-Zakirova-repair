using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopContracts.BindingModels;
using AutorepairShopContracts.ViewModels;

namespace AutorepairShopContracts.BusinessLogicsContracts
{
    public interface IStorehouseLogic
    {
        List<StorehouseViewModel> Read(StorehouseBindingModel model);
        void CreateOrUpdate(StorehouseBindingModel model);
        void Delete(StorehouseBindingModel model);
        void Replenishment(StorehouseReplenishmentBindingModel model);
    }
}
