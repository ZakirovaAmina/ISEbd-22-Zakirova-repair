﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorepairShopContracts.BindingModels
{
    /// <summary>
    /// Склад
    /// </summary>
    public class StorehouseBindingModel
    {
        public int? Id { get; set; }
        public string StorehouseName { get; set; }
        public string ResponsiblePerson { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }

    }
}
