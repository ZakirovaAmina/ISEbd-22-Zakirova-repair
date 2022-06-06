using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AutorepairShopContracts.Attributes;

namespace AutorepairShopContracts.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class ComponentViewModel
    {
        public int Id { get; set; }
        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
