using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopContracts.BindingModels;
using AutorepairShopContracts.StoragesContracts;
using AutorepairShopContracts.ViewModels;
using AutorepairShopListImplement.Models;


namespace AutorepairShopListImplement.Implements
{
    public class RepairStorage : IRepairStorage
    {
        private readonly DataListSingleton source;
        public RepairStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<RepairViewModel> GetFullList()
        {
            var result = new List<RepairViewModel>();
            foreach (var component in source.Repairs)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<RepairViewModel> GetFilteredList(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<RepairViewModel>();
            foreach (var product in source.Repairs)
            {
                if (product.RepairName.Contains(model.repair))
                {
                    result.Add(CreateModel(product));
                }
            }
            return result;
        }
        public RepairViewModel GetElement(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var product in source.Repairs)
            {
                if (product.Id == model.Id || product.RepairName ==
                model.repair)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }
        public void Insert(RepairBindingModel model)
        {
            var tempProduct = new Repair
            {
                Id = 1,
                RepairComponents = new Dictionary<int, int>()
            };
            foreach (var product in source.Repairs)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Repairs.Add(CreateModel(model, tempProduct));
        }
        public void Update(RepairBindingModel model)
        {
            Repair tempProduct = null;
            foreach (var product in source.Repairs)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }
        public void Delete(RepairBindingModel model)
        {
            for (int i = 0; i < source.Repairs.Count; ++i)
            {
                if (source.Repairs[i].Id == model.Id)
                {
                    source.Repairs.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Repair CreateModel(RepairBindingModel model, Repair
        product)
        {
            product.RepairName = model.repair;
            product.Price = model.Price;
     
            foreach (var key in product.RepairComponents.Keys.ToList())
            {
                if (!model.RepairComponents.ContainsKey(key))
                {
                    product.RepairComponents.Remove(key);
                }
            }
            
            foreach (var component in model.RepairComponents)
            {
                if (product.RepairComponents.ContainsKey(component.Key))
                {
                    product.RepairComponents[component.Key] =
                    model.RepairComponents[component.Key].Item2;
                }
                else
                {
                    product.RepairComponents.Add(component.Key,
                    model.RepairComponents[component.Key].Item2);
                }
            }
            return product;
        }
        private RepairViewModel CreateModel(Repair product)
        {

            var productComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in product.RepairComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new RepairViewModel
            {
                Id = product.Id,
                RepairName = product.RepairName,
                Price = product.Price,
                RepairComponents = productComponents
            };
        }
    }
}

