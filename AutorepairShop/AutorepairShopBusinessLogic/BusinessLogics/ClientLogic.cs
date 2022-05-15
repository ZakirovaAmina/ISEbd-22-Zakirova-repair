﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopContracts.BindingModels;
using AutorepairShopContracts.BusinessLogicsContracts;
using AutorepairShopContracts.StoragesContracts;
using AutorepairShopContracts.ViewModels;

namespace AutorepairShopBusinessLogic.BusinessLogics
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientStorage _clientStorage;
        public ClientLogic(IClientStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }
        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ClientViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel
            {
                Email = model.Email
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Клиент с таким логином уже есть");
            }
            if (model.Id.HasValue)
            {
                _clientStorage.Update(model);
            }
            else
            {
                _clientStorage.Insert(model);
            }
        }
        public void Delete(ClientBindingModel model)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Клиент не найден");
            }
            _clientStorage.Delete(model);
        }
    }
}
