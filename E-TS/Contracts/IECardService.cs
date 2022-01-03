using E_TS.ViewModels.ECard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Contracts
{
    public interface IECardService
    {
        ECardsViewModel GetECardsViewModel();

    }
}
