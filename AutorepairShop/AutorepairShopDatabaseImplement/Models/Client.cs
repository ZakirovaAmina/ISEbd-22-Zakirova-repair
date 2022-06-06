﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutorepairShopDatabaseImplement.Models
{
   public class Client
    {
        public int Id { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [ForeignKey("ClientId")]
        public List<Order> Orders { get; set; }

        [ForeignKey("ClientId")]
        public List<MessageInfo> MessageInfoes { get; set; }
    }
}
