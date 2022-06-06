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
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        private readonly string MessageInfoFileName = "MessageInfo.xml";

        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Repair> Repairs { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfoes { get; set; }


        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Repairs = LoadProducts();
            Clients = LoadClients();
            MessageInfoes = LoadMessageInfoes();
            Implementers = LoadImplementers();

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
            GetInstance().SaveRepairs();
            GetInstance().SaveOrders();
            GetInstance().SaveClients();
            GetInstance().SaveMessageInfoes();
            GetInstance().SaveImplementers();

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
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        RepairId = Convert.ToInt32(elem.Element("RepairId").Value),
                        ImplementerId = Convert.ToInt32(elem.Element("ImplementerId").Value),
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
        private List<Repair> LoadProducts()
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
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value,
                    });
                }
            }
            return list;
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();

            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value),
                    });
                }
            }
            return list;
        }
        private List<MessageInfo> LoadMessageInfoes()
        {
            var list = new List<MessageInfo>();

            if (File.Exists(MessageInfoFileName))
            {
                XDocument xDocument = XDocument.Load(MessageInfoFileName);
                var xElements = xDocument.Root.Elements("MessageInfo").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        SenderName = elem.Element("SenderName").Value,
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery")?.Value),
                        Subject = elem.Element("Subject").Value,
                        Body = elem.Element("Body").Value,
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
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");

                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
        private void SaveMessageInfoes()
        {
            if (MessageInfoes != null)
            {
                var xElement = new XElement("MessageInfoes");

                foreach (var message in MessageInfoes)
                {
                    xElement.Add(new XElement("MessageInfo",
                    new XAttribute("MessageId", message.MessageId),
                    new XElement("ClientId", message.ClientId),
                    new XElement("SenderName", message.SenderName),
                    new XElement("DateDelivery", message.DateDelivery),
                    new XElement("Subject", message.Subject),
                    new XElement("Body", message.Body)
                    ));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MessageInfoFileName);
            }
        }
    }
}
