using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutorepairShopContracts.Enums;

namespace AutorepairShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public virtual Repair Repair { get; set; }

        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
