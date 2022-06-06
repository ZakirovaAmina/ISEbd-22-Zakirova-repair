using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopContracts.Attributes;

namespace AutorepairShopContracts.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class RepairViewModel
    {
        public int Id { get; set; }
        [Column(title: "Название ремонта", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string RepairName { get; set; }
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> RepairComponents { get; set; }
    }
}
