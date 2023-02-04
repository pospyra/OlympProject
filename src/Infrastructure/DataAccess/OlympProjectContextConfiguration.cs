using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OlympProjectContextConfiguration : IDbContextOptionsConfigurator<OlympProjectContext>
    {
        private const string PostgresConnectionStringName = "PostgresOlympDb";
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public OlympProjectContextConfiguration(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public void Configure(DbContextOptionsBuilder<OlympProjectContext> options)
        {
            string connectionString = _configuration.GetConnectionString(PostgresConnectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Не найдена строка подключения с именем '(ConnectionStringName)'");
            }
            options.UseNpgsql(connectionString)
                .UseLoggerFactory(_loggerFactory); ;
        }
    }
}
