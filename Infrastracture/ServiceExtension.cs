using Application.Interfaces;
using Infrastracture.Persistence;
using Infrastracture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
{
    public static class ServiceExtension
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddDbContext<ApplicationDbContext>(opt=> opt.UseInMemoryDatabase("Todos"));
            return service;
        }
    }
}
