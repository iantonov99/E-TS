using E_TS.ViewModels.ECard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Contracts
{
    public interface IECardService
    {
        ECardsViewModel GetECardsViewModel(string userId);

        bool SaveData(ECardViewModel model);

        bool SaveDataTrips(ECardTripsViewModel model);

    }
}
