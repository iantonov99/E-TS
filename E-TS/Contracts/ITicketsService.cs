using E_TS.Models;
using E_TS.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Contracts
{
    public interface ITicketsService
    {
        /// <summary>
        /// метод за взимане на всички редове от базата за билети
        /// </summary>
        /// <returns></returns>
        List<TicketViewModel> GetTickets(string userId);

        /// <summary>
        /// метод за взимане на всички редове от базата за  билети по подадени параметри
        /// </summary>
        /// <returns></returns>
        List<TicketViewModel> GetTickets(bool isBought, decimal ticketPrice, string ticketName);

        /// <summary>
        /// запазване на данните в базата от данни
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveData(TicketViewModel model);
        /// <summary>
        /// взима запис от базата по идентификатор
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TicketViewModel GetTicketViewModelById(int Id);
        /// <summary>
        /// Изтрива резервация от базата данни
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool DeleteTicket(int Id);

        /// <summary>
        /// Записва билет в базата данни
        /// </summary>
        /// <param name="isBought"></param><param name="ticketPrice"></param><param name="ticketName"></param>
        /// <returns></returns>
        public bool createUserTickets(bool isBought, decimal ticketPrice, string ticketName, string userId);
    }
}
