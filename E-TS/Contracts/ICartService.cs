using E_TS.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Contracts
{
    public interface ICartService
    {
        /// <summary>
        /// връща записи за продукти в количката по UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<CartViewModel> GetCartViewModels(string UserId);

        /// <summary>
        /// премахва продукт от количката
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Table"></param>
        /// <returns></returns>
        bool Remove(int Id, int Table);
        /// <summary>
        /// Обръща стойността на true на пропъртито isBought на всички услуги
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        bool BuyAll(string UserId);

        /// <summary>
        /// Обръща стойността на true на пропъртито isBought на една услуги
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Table"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        bool Buy(int Id, int Table, string UserId);

    }
}
