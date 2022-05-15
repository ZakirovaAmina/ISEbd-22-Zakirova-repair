using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AutorepairShopContracts.Enums;

namespace AutorepairShopContracts.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderViewModel
    {
        /* public int Id { get; set; }
         public int RepairId { get; set; }
         [DisplayName("Ремонт")]
         public string RepairName { get; set; }
         public int ClientId { get; set; }
         [DisplayName("ФИО клиента")]
         public string ClientFIO { get; set; }
         [DisplayName("Количество")]
         public int Count { get; set; }
         [DisplayName("Сумма")]
         public decimal Sum { get; set; }
         [DisplayName("Статус")]
         public OrderStatus Status { get; set; }
         [DisplayName("Дата создания")]
         public DateTime DateCreate { get; set; }
         [DisplayName("Дата выполнения")]
         public DateTime? DateImplement { get; set; }*/
        public int Id { get; set; }
        public int RepairId { get; set; }
        public int ClientId { get; set; }
        public string RepairName { get; set; }
        public int Count { get; set; }
        public string ClientFIO { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
