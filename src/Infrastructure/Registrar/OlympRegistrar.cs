using AppServices.IRepository;
using AppServices.MappingProfile;
using AppServices.Services.Account;
using AppServices.Services.Animal;
using AppServices.Services.AnimalType;
using AppServices.Services.LocationPoint;
using AppServices.Services.VisitedLocation;
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
using AutoMapper;
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


            //services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));


            services.AddAutoMapper(typeof(AccountMapProfile), typeof(AnimalMapProfile),
                typeof(AnimalTypeMapProfile), typeof(LocationPointMapProfile), typeof(VisitedLocatiomMapProfile));

            //регистрация аккаунта
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            //регистрация животного
            services.AddTransient<IAnimalService, AnimalService>();
            services.AddTransient<IAnimalRepository, AnimalRepository>();

            //регистрация типа животного
            services.AddTransient<IAnimalTypeService, AnimalTypeService>();
            services.AddTransient<IAnimalTypeRepository, AnimalTypeRepository>();

            //регистрация точки локации
            services.AddTransient<ILocationPointService, LocationPointService>();
            services.AddTransient<ILocationPointRepository, LocationPointRepository>();

            //регистрация точки посещенной животным
            services.AddTransient<IVisitedLocationService, VisitedLocationService>();
            services.AddTransient<IAnimalVisitedLocationRepository, AnimalVisitedLocationRepository>();

            return services;
        }
        //private static MapperConfiguration GetMapperConfiguration()
        //{
        //    var mapperCongig = new MapperConfiguration(config =>
        //    {
        //        config.AddProfile(new AccountMapProfile());
        //        config.AddProfile(new AnimalMapProfile());
        //        config.AddProfile(new AnimalTypeMapProfile());
        //        config.AddProfile(new LocationPointMapProfile());
        //        config.AddProfile(new VisitedLocatiomMapProfile());
        //    });
        //   // mapperCongig.AssertConfigurationIsValid();
        //    return mapperCongig;
        //}
    }
}
