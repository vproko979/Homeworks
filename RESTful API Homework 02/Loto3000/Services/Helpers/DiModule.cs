using DataAccess;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Helpers
{
    public static class DiModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<UserDTO>, UserRepository>();
            services.AddTransient<IRepository<TicketDTO>, TicketRepository>();
            services.AddTransient<IRepository<DrawingDTO>, DrawingRepository>();
            services.AddTransient<IRepository<SessionDTO>, SessionRepository>();
            services.AddTransient<IRepository<WinnersDTO>, WinnersRepository>();
            services.AddTransient<IRepository<PrizeDTO>, PrizeRepository>();
            services.AddDbContext<LotoDbContext>(x => x.UseSqlServer(connectionString));

            return services;
        }
    }
}
