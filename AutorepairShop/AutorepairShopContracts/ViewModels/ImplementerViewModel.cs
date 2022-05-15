﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace AutorepairShopContracts.ViewModels
{
    public class ImplementerViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО исполнителя")]
        public string ImplementerFIO { get; set; }
        [DisplayName("Время на заказ")]
        public int WorkingTime { get; set; }
        [DisplayName("Время на перерыв")]
        public int PauseTime { get; set; }
    }
}
