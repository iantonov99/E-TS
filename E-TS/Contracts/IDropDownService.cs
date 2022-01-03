using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Contracts
{
    public interface IDropDownService
    {
        SelectList GetTransportTypes();

        SelectList GetTransportLines();
    }
}
