using AlifTj.DataAccess.DbContexts;
using AlifTj.DataAccess.Interfaces;
using AlifTj.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlifTj.Api.Configurationts
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
