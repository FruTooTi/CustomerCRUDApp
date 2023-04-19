using CustomerCRUDApp_DAL.AppDbContext;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp.Infrastructure.Middlewares
{
    public class SaveChanges
    {
        private readonly RequestDelegate _next;
        public SaveChanges(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ApplicationDbContext _dbContext)
        {
            await _next(context);
            int changes = await _dbContext.SaveChangesAsync();
        }
    }
}
