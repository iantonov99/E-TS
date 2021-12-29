using E_TS.Data.Models;
using E_TS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TS.Extensions
{
    /// <summary>
    /// Описва услугите и контекстите на приложението
    /// </summary>
    public static class E_TicketsServiceCollectionExtension
    {
        /// <summary>
        /// Регистрира услугите на приложението в  IoC контейнера
        /// </summary>
        /// <param name="services">Регистрирани услуги</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //services.AddHttpContextAccessor();

        }

        /// <summary>
        /// Регистрира Identity provider в IoC контейнера
        /// </summary>
        /// <param name="services">Регистрирани услуги</param>
        public static void AddApplicationIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
