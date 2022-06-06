﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AutorepairShopContracts.ViewModels
{
    public class StorehouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string StorehouseName { get; set; }
        [DisplayName("ФИО ответственного")]
        public string ResponsiblePerson { get; set; }
        [DisplayName("Дата создания склада")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}
