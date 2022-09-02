using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Persistance.Contexts;
using Kodlama.Io.Devs.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                        IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("SqlServerConnectionString")));
            services.AddScoped<IProgramingLanguageRepository, ProgramingLanguageRepository>();
            
            return services;
        }
    }
}
