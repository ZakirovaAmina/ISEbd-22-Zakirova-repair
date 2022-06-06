using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopListImplement.Models;



namespace AutorepairShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Repair> Repairs { get; set; }
        public List<Storehouse> Storehouses { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Repairs = new List<Repair>();
            Storehouses = new List<Storehouse>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
                
        {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
