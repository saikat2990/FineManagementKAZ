
using Core.Interfaces;
using DotNetCore.IoC;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.BaseRepository;

namespace DotNetLearn
{
    public  static class DBExternsions
    {
        public static void AddDbContexts(this IServiceCollection services)
        {
            var connectionString = services.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(connectionString,
                    optionsAction => optionsAction.EnableRetryOnFailure()));
            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(10); });
        }

        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepositories, EmployeeRepositories>();
        }
    }
}
