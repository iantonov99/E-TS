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

    }
}
