using E_TS.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Contracts
{
    public interface ICartService
    {
        List<CartViewModel> GetCartViewModels(string UserId);

        bool Remove(int Id, int Table);

    }
}
