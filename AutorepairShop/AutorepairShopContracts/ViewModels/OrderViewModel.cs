using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AutorepairShopContracts.Enums;
using AutorepairShopContracts.Attributes;

namespace AutorepairShopContracts.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 30)]
        public int Id { get; set; }
        public int RepairId { get; set; }
        public int ClientId { get; set; }
        [Column(title: "Ремонты", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string RepairName { get; set; }
        public int? ImplementerId { get; set; }
        [Column(title: "Количество", width: 30)]
        public int Count { get; set; }
        [Column(title: "Клиент", width: 70)]
        public string ClientFIO { get; set; }
        [Column(title: "Исполнитель", width: 100)]
        public string ImplementerFIO { get; set; }
        [Column(title: "Сумма", width: 60)]
        public decimal Sum { get; set; }
        [Column(title: "Статус", width: 70)]
        public OrderStatus Status { get; set; }
        [Column(title: "Дата создания", width: 110)]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата выполнения", width: 110)]
        public DateTime? DateImplement { get; set; }
    }
}
