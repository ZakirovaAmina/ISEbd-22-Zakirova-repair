using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AutorepairShopContracts.Attributes;


namespace AutorepairShopContracts.ViewModels
{
    public class ImplementerViewModel
    {
        public int Id { get; set; }
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }
        [Column(title: "Время на заказ", width: 100)]
        public int WorkingTime { get; set; }
        [Column(title: "Время на перерыв", width: 100)]
        public int PauseTime { get; set; }
    }
}
