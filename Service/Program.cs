using Data.Repositories.Classes.Derived;
using Data.Repositories.Interfaces.Derived;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Threading.Tasks;
using WebClients;

namespace HH_RU_Parser.Service
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddSingleton<VacanciesRequester>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
    .AddPostgres()
    .WithGlobalConnectionString(connectionString) // Add this line if you are missing the connection string
    .ConfigureGlobalProcessorOptions(opt =>
    {
        opt.ProviderSwitches = "Force Quote=false";
    })
    .ScanIn(typeof(Data.Migrations.InitialMigration).Assembly).For.Migrations());



            builder.Services.AddScoped<IAddressesRepository, AddressesRepository>(instance => new AddressesRepository(connectionString));
            builder.Services.AddScoped<IAreasRepository, AreasRepository>(instance => new AreasRepository(connectionString));
            builder.Services.AddScoped<IBrandingsRepository, BrandingsRepository>(instance => new BrandingsRepository(connectionString));
            builder.Services.AddScoped<IEmployersRepository, EmployersRepository>(instance => new EmployersRepository(connectionString));
            builder.Services.AddScoped<IEmploymentsRepository, EmploymentsRepository>(instance => new EmploymentsRepository(connectionString));
            builder.Services.AddScoped<IExperiencesRepository, ExperiencesRepository>(instance => new ExperiencesRepository(connectionString));
            builder.Services.AddScoped<ILogoUrlsesRepository, LogoUrlsesRepository>(instance => new LogoUrlsesRepository(connectionString));
            builder.Services.AddScoped<IProfessionalRolesRepository, ProfessionalRolesRepository>(instance => new ProfessionalRolesRepository(connectionString));
            builder.Services.AddScoped<IRootsRepository, RootsRepository>(instance => new RootsRepository(connectionString));
            builder.Services.AddScoped<ISalariesRepository, SalariesRepository>(instance => new SalariesRepository(connectionString));
            builder.Services.AddScoped<ISchedulesRepository, SchedulesRepository>(instance => new SchedulesRepository(connectionString));
            builder.Services.AddScoped<ISnippetsRepository, SnippetsRepository>(instance => new SnippetsRepository(connectionString));
            builder.Services.AddScoped<ITypesRepository, TypesRepository>(instance => new TypesRepository(connectionString));
            builder.Services.AddScoped<IVacanciesRepository, VacanciesRepository>(instance => new VacanciesRepository(connectionString));

            builder.Services.AddHostedService<Worker>();
            IHost host = builder.Build();
            using (var scope = host.Services.CreateScope())
            {
                var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                migrator.MigrateUp();
            }
            host.Run();

        }
    }
}