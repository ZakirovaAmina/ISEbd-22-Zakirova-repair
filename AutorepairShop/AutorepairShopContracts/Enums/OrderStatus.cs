using System;
using System.Collections.Generic;
using System.Text;

namespace AutorepairShopContracts.Enums
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public enum OrderStatus
    {
        Принят = 0,
        Выполняется = 1,
        Готов = 2,
        Выдан = 3
    }
}
