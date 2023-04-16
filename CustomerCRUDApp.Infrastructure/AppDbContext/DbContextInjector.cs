using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_DAL.AppDbContext
{
    public static class DbContextInjector
    {
        public static void InjectDbContext(this IServiceCollection services, string? connectionStr)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionStr), ServiceLifetime.Scoped);
        }
    }
}
