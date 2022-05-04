using AutorepairShopContracts.BindingModels;
using AutorepairShopContracts.StoragesContracts;
using AutorepairShopContracts.ViewModels;
using AutorepairShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutorepairShopListImplement.Implements
{
    public class OrderStorage: IOrderStorage
    {
        private readonly DataListSingleton source;
        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                result.Add(CreateModel(order));
            }
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (order.RepairId.ToString().Contains(model.RepairId.ToString()) || order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var component in source.Orders)
            {
                if (component.Id == model.Id || component.RepairId ==
               model.RepairId)
                {
                    return CreateModel(component);
                }
            }
            return null;
        }
        public void Insert(OrderBindingModel model)
        {
            Order tempOrder = new Order { Id = 1 };
            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempOrder));
        }
        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (tempOrder == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempOrder);
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.RepairId = model.RepairId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateImplement = model.DateImplement;
            order.DateCreate = model.DateCreate;
            return order;
        }
        private OrderViewModel CreateModel(Order order)
        {
            string repairName = "";
            foreach (var repair in source.Repairs)
            {
                if (repair.Id == order.RepairId)
                {
                    repairName = repair.RepairName;
                }
            }

            return new OrderViewModel
            {
                Id = order.Id,
                RepairId = order.RepairId,
                Sum = order.Sum,
                Count = order.Count,
                Status = order.Status,
                RepairName = repairName,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
