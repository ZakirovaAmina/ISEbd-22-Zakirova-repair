using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using AutorepairShopContracts.Enums;
using AutorepairShopFileImplement.Models;

namespace AutorepairShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string RepairFileName = "Repair.xml";
        private readonly string StorehouseFileName = "Storehouse.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Repair> Repairs { get; set; }
        public List<Storehouse> Storehouses { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Repairs = LoadRepairs();
            Storehouses = LoadStorehouses();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        public static void SaveAll()
        {
            GetInstance().SaveComponents();
            GetInstance().SaveOrders();
            GetInstance().SaveRepairs();
            GetInstance().SaveStorehouses();
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveRepairs();
            SaveStorehouses();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    OrderStatus status = 0;
                    switch (elem.Element("Status").Value)
                    {
                        case "Принят":
                            status = OrderStatus.Принят;
                            break;
                        case "Выполняется":
                            status = OrderStatus.Выполняется;
                            break;
                        case "Готов":
                            status = OrderStatus.Готов;
                            break;
                        case "Выдан":
                            status = OrderStatus.Выдан;
                            break;
                    }

                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        RepairId = Convert.ToInt32(elem.Element("RepairId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = status,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }
        private List<Repair> LoadRepairs()
        {
            var list = new List<Repair>();
            if (File.Exists(RepairFileName))
            {
                var xDocument = XDocument.Load(RepairFileName);
                var xElements = xDocument.Root.Elements("Repair").ToList();
                foreach (var elem in xElements)
                {
                    var repComp = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("RepairComponents").Elements("RepairComponent").ToList())
                    {
                        repComp.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Repair
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        RepairName = elem.Element("RepairName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        RepairComponents = repComp
                    });
                }
            }
            return list;
        }
        private List<Storehouse> LoadStorehouses()
        {
            var list = new List<Storehouse>();
            if (File.Exists(StorehouseFileName))
            {
                var xDocument = XDocument.Load(StorehouseFileName);
                var xElements = xDocument.Root.Elements("Storehouse").ToList();
                foreach (var elem in xElements)
                {
                    var WHComp = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("StorehouseComponents").Elements("StorehouseComponent").ToList())
                    {
                        WHComp.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Storehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StorehouseName = elem.Element("StorehouseName").Value,
                        ResponsiblePerson = elem.Element("ResponsiblePerson").Value,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        StorehouseComponents = WHComp
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                var xDocument = new XDocument(xElement);

                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {

            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("RepairId", order.RepairId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));

                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }

        }
        private void SaveRepairs()
        {
            if (Repairs != null)
            {
                var xElement = new XElement("Repairs");
                foreach (var repair in Repairs)
                {
                    var compElement = new XElement("RepairComponents");
                    foreach (var component in repair.RepairComponents)
                    {
                        compElement.Add(new XElement("RepairComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Repair",
                     new XAttribute("Id", repair.Id),
                     new XElement("RepairName", repair.RepairName),
                     new XElement("Price", repair.Price),
                     compElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(RepairFileName);
            }
        }
        private void SaveStorehouses()
        {
            if (Storehouses != null)
            {
                var xElement = new XElement("Storehouses");
                foreach (var warehouse in Storehouses)
                {
                    var warehouseElement = new XElement("StorehouseComponents");
                    foreach (var component in warehouse.StorehouseComponents)
                    {
                        warehouseElement.Add(new XElement("StorehouseComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Storehouse",
                     new XAttribute("Id", warehouse.Id),
                     new XElement("StorehouseName", warehouse.StorehouseName),
                     new XElement("ResponsiblePerson", warehouse.ResponsiblePerson),
                     new XElement("DateCreate", warehouse.DateCreate),
                     warehouseElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(StorehouseFileName);
            }
        }
    }
}