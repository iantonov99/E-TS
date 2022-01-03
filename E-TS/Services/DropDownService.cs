using E_TS.Contracts;
using E_TS.Data.Common;
using E_TS.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Services
{
    public class DropDownService : IDropDownService
    {
        private readonly IRepository _repo;
        public DropDownService(IRepository repo)
        {
            _repo = repo;
        }

        public SelectList GetTransportTypes()
        {
            var list = new SelectList(_repo.All<TransportType>(), "Id", "Type");

            return list;
        }

        public SelectList GetTransportLines()
        {
            var list = new SelectList(_repo.All<TransportLines>(), "Id", "Number");

            return list;
        }
    }
}
