using Data.Repositories.Interfaces.Derived;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebClients;

namespace HH_RU_Parser.Service;

public sealed class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;
    private readonly VacanciesRequester _vacanciesRequester;
    private readonly IAddressesRepository _addressesRepository;
    private readonly IAreasRepository _areasRepository;
    private readonly IBrandingsRepository _brandingsRepository;
    private readonly IEmployersRepository _employersRepository;
    private readonly IEmploymentsRepository _employmentsRepository;
    private readonly IExperiencesRepository _experiencesRepository;
    private readonly ILogoUrlsesRepository _logoUrlsesRepository;
    private readonly IProfessionalRolesRepository _professionalRolesRepository;
    private readonly IRootsRepository _rootsRepository;
    private readonly ISalariesRepository _salariesRepository;
    private readonly ISchedulesRepository _schedulesRepository;
    private readonly ISnippetsRepository _snippetsRepository;
    private readonly ITypesRepository _typesRepository;
    private readonly IVacanciesRepository _vacanciesRepository;

    public Worker(ILogger<Worker> logger, IConfiguration configuration, VacanciesRequester vacanciesRequester,
        IAddressesRepository addressesRepository, IAreasRepository areasRepository, IBrandingsRepository brandingsRepository, IEmployersRepository employersRepository, IEmploymentsRepository employmentsRepository,
        IExperiencesRepository experiencesRepository, ILogoUrlsesRepository logoUrlsesRepository, IProfessionalRolesRepository professionalRolesRepository, IRootsRepository rootsRepository, ISalariesRepository salariesRepository,
        ISchedulesRepository schedulesRepository, ISnippetsRepository snippetsRepository, ITypesRepository typesRepository, IVacanciesRepository vacanciesRepository)
    {
        _logger = logger;
        _configuration = configuration;
        _vacanciesRequester = vacanciesRequester;
        _addressesRepository = addressesRepository;
        _areasRepository = areasRepository;
        _brandingsRepository = brandingsRepository;
        _employersRepository = employersRepository;
        _employmentsRepository = employmentsRepository;
        _experiencesRepository = experiencesRepository;
        _logoUrlsesRepository = logoUrlsesRepository;
        _professionalRolesRepository = professionalRolesRepository;
        _rootsRepository = rootsRepository;
        _salariesRepository = salariesRepository;
        _schedulesRepository = schedulesRepository;
        _snippetsRepository = snippetsRepository;
        _typesRepository = typesRepository;
        _vacanciesRepository = vacanciesRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const int DAY_IN_MILLISECONDS = 24 * 60 * 60 * 1000;


        while (!stoppingToken.IsCancellationRequested)
        {
            var page = 0;
            var vacancies = await _vacanciesRequester.GetVacanciesAsync($"vacancies?text=C%23+ASP+Entity+Dapper+SQL&schedule=remote");

            foreach (var vacancy in vacancies)
            {
                if (vacancy.Address is not null)
                {
                    await _addressesRepository.AddAsync(vacancy.Address);
                }

                if (vacancy.Area is not null)
                {
                    await _areasRepository.AddAsync(vacancy.Area);
                }
                if (vacancy.Branding is not null)
                {
                    await _brandingsRepository.AddAsync(vacancy.Branding);
                }
                if (vacancy.Employer is not null)
                {
                    await _employersRepository.AddAsync(vacancy.Employer);
                }
                if (vacancy.Employment is not null)
                {
                    await _employmentsRepository.AddAsync(vacancy.Employment);
                }
                if (vacancy.Experience is not null)
                {
                    await _experiencesRepository.AddAsync(vacancy.Experience);
                }
                if (vacancy.Salary is not null)
                {
                    await _salariesRepository.AddAsync(vacancy.Salary);
                }
                if (vacancy.Schedule is not null)
                {
                    await _schedulesRepository.AddAsync(vacancy.Schedule);
                }
                if (vacancy.Snippet is not null)
                {
                    await _snippetsRepository.AddAsync(vacancy.Snippet);
                }
                if (vacancy.Type is not null)
                {
                    await _typesRepository.AddAsync(vacancy.Type);
                }
                await _vacanciesRepository.AddAsync(vacancy);

            }
            await Task.Delay(DAY_IN_MILLISECONDS, stoppingToken);
        }
    }
}