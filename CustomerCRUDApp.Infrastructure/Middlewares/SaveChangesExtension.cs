using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp.Infrastructure.Middlewares
{
    public static class SaveChangesExtension
    {
        public static IApplicationBuilder UseSaveChanges(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SaveChanges>();
        }
    }
}
