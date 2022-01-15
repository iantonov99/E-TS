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
            var defaultValue = new List<SelectListItem>();
            defaultValue.Add(new SelectListItem { Text = "Всички", Value = null });

            var list = new SelectList(defaultValue, "Value", "Text");

            return list;
        }

        public List<SelectListItem> GetTransportLinesByTransportType(int? TransportType)
        {
            if(TransportType == null)
            {
                return new List<SelectListItem>() { new SelectListItem { Text = "Всички", Value = null } };
            }


            return _repo.AllReadonly<TransportLines>()
                        .Where(t => t.TransportTypeId == TransportType)
                        .Select(t => new SelectListItem
                        {
                            Text = t.Number.ToString(),
                            Value = t.Id.ToString()
                        }).ToList();
        }

        public SelectList GetPeriods()
        {
            var periods = new List<SelectListItem>
            {
                new SelectListItem { Text = "1 Месец", Value = "1" },
                new SelectListItem { Text = "3 Месеца", Value = "2" },
                new SelectListItem { Text = "6 Месеца", Value = "3" },
                new SelectListItem { Text = "1 Година", Value = "4" }
            };

            var list = new SelectList(periods, "Value", "Text");

            return list;
        }
    }
}
