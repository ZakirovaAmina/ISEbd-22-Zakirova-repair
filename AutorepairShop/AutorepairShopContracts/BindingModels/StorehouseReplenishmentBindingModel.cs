﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorepairShopContracts.BindingModels
{
    public class StorehouseReplenishmentBindingModel
    {
        public int StorehouseId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
