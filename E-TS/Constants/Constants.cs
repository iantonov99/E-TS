﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Constants
{
    public static class Constants
    {
        public const string ErrorMessage = "ErrorMessage";
        public const string SuccessMessage = "SuccessMessage";

        public static class Values
        {
            public const string SaveOk = "Записът премина успешно";
            public const string SavedFailed = "Проблемпо време на запис";
        }

        public static string[] Transports = { "Всички", "Трамвай", "Тролей", "Автобус", "Метро" };

        public const int TicketTable = 1;
        public const int ECardTable = 2;
        public const int ECardTripsTable = 3;
        public const int ReservationTable = 4;

    }
}
