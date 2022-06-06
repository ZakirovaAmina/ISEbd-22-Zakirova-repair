using System;
using System.Collections.Generic;
using AutorepairShopContracts.BindingModels;
using AutorepairShopContracts.BusinessLogicsContracts;
using AutorepairShopContracts.StoragesContracts;
using AutorepairShopContracts.ViewModels;
using AutorepairShopContracts.Enums;


namespace AutorepairShopBusinessLogic.BusinessLogics
{
    public class OrderLogic: IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IStorehouseStorage _storehouseStorage;
        private readonly IRepairStorage _repairStorage;
        public OrderLogic(IOrderStorage orderStorage, IStorehouseStorage storehouseStorage, IRepairStorage repairStorage)
        {
            _orderStorage = orderStorage;
            _storehouseStorage = storehouseStorage;
            _repairStorage = repairStorage;
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                RepairId = model.RepairId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            if (!_storehouseStorage.WriteOffFromStorehouses(_repairStorage.GetElement(new RepairBindingModel { Id = order.RepairId }).RepairComponents, order.Count))
            {
                throw new Exception("Недостаточно компонентов");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                RepairId = order.RepairId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Выполняется
            });
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id =
           model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                RepairId = order.RepairId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }
        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                RepairId = order.RepairId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Выдан
            });

        }
    }
}
