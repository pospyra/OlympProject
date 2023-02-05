using AppServices.IRepository;
using AppServices.Services.Account;
using AppServices.Services.Animal;
using DataAccess;
using DataAccess.RepositoryImplemented;
using Infrastructure.BaseRepositoty;
using Infrastructure.Repositoty;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registrar
{

    public static class OlympRegistrar 
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddSingleton<IDbContextOptionsConfigurator<OlympProjectContext>, OlympProjectContextConfiguration>();

            services.AddDbContext<OlympProjectContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
                ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<OlympProjectContext>>()
                .Configure((DbContextOptionsBuilder<OlympProjectContext>)dbOptions)));

            services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<OlympProjectContext>()));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IAnimalService, AnimalService>();
            services.AddTransient<IAnimalRepository, AnimalRepository>();

            return services;
        }
    }
}
