using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AutorepairShopContracts.Attributes;

namespace AutorepairShopContracts.ViewModels
{
   public class ClientViewModel
    {
        public int Id { get; set; }
        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }
        [Column(title: "Логин", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Email { get; set; }
        [Column(title: "Пароль", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Password { get; set; }
    }
}
