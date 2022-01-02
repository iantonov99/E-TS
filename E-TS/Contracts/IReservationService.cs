using E_TS.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Contracts
{
    public interface IReservationService
    {
        /// <summary>
        /// метод за взимане на всички редове от базата за резервации
        /// </summary>
        /// <returns></returns>
        List<ReservationsTableViewModel> GetReservations();
        /// <summary>
        /// запазване на данните в базата от данни
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveData(ReservationViewModel model);
        /// <summary>
        /// взима запис от базата по идентификатор
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ReservationViewModel GetReservationViewModelById(int Id);
        /// <summary>
        /// Изтрива резервация от базата данни
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool DeleteReservation(int Id);

    }
}
