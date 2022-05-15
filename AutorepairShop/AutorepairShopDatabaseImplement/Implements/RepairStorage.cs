using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopContracts.BindingModels;
using AutorepairShopContracts.StoragesContracts;
using AutorepairShopContracts.ViewModels;
using AutorepairShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AutorepairShopDatabaseImplement.Implements
{
    public class RepairStorage: IRepairStorage
    {
        public List<RepairViewModel> GetFullList()
        {
            using var context = new AutorepairShopDatabase();
            return context.Repairs
            .Include(rec => rec.RepairComponents)
            .ThenInclude(rec => rec.Component)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<RepairViewModel> GetFilteredList(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AutorepairShopDatabase();
            return context.Repairs
            .Include(rec => rec.RepairComponents)
            .ThenInclude(rec => rec.Component)
            .Where(rec => rec.RepairName.Contains(model.repair))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public RepairViewModel GetElement(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AutorepairShopDatabase();
            var repair = context.Repairs
            .Include(rec => rec.RepairComponents)
            .ThenInclude(rec => rec.Component)
            .FirstOrDefault(rec => rec.RepairName == model.repair || rec.Id == model.Id);
            return repair != null ? CreateModel(repair) : null;
        }
        public void Insert(RepairBindingModel model)
        {
            using var context = new AutorepairShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Repair repair = new Repair()
                {
                    RepairName = model.repair,
                    Price = model.Price
                };
                context.Repairs.Add(repair);
                context.SaveChanges();
                CreateModel(model, repair, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(RepairBindingModel model)
        {
            using var context = new AutorepairShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Repairs.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(RepairBindingModel model)
        {
            using var context = new AutorepairShopDatabase();
            Repair element = context.Repairs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Repairs.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Repair CreateModel(RepairBindingModel model, Repair repair, AutorepairShopDatabase context)
        {
            repair.RepairName = model.repair;
            repair.Price = model.Price;
            if (model.Id.HasValue)
            {
                var repairComponents = context.RepairComponents.Where(rec =>
               rec.RepairId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.RepairComponents.RemoveRange(repairComponents.Where(rec =>
               !model.RepairComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in repairComponents)
                {
                    updateComponent.Count =
                   model.RepairComponents[updateComponent.ComponentId].Item2;
                    model.RepairComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.RepairComponents)
            {
                context.RepairComponents.Add(new RepairComponent
                {
                    RepairId = repair.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return repair;
        }
        private static RepairViewModel CreateModel(Repair repair)
        {
            return new RepairViewModel
            {
                Id = repair.Id,
                RepairName = repair.RepairName,
                Price = repair.Price,
                RepairComponents = repair.RepairComponents
            .ToDictionary(recPC => recPC.ComponentId,
            recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }
    }
}
