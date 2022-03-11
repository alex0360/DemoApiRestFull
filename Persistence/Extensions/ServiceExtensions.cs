using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;
using static Persistence.Local.Settings;

namespace Persistence.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var parameter = new Parameterize(configuration);
            //var connectionString = new Connector(parameter.DataSource, parameter.DataBase, parameter.UserId, parameter.PasswordServer).ConnectionString;
            var connectionString = new Connector(parameter.Path, parameter.Cache, parameter.PasswordLite).ConnectionString;

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(
                connectionString
               )
            );

            #region Repository
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            #endregion
        }
    }
}