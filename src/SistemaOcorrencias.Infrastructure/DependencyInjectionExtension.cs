using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaOcorrencias.Domain.Repositories;
using SistemaOcorrencias.Domain.Repositories.Classroom;
using SistemaOcorrencias.Domain.Repositories.Student;
using SistemaOcorrencias.Domain.Repositories.User;
using SistemaOcorrencias.Infrastructure.DataAccess;
using SistemaOcorrencias.Infrastructure.DataAccess.Repositories;

namespace SistemaOcorrencias.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });
    }
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IClassroomRepository, ClassroomRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
