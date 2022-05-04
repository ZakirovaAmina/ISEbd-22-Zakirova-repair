using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorepairShopContracts.BindingModels;
using AutorepairShopContracts.ViewModels;


namespace AutorepairShopContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        /// <summary>

        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        List<ReportRepairComponentViewModel> GetRepairComponent();
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveComponentsToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveRepairComponentToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
