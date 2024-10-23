using Data.Repositories.Interfaces.Derived;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
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
            IEnumerable<Vacancy> vacanciesFrom1To3Experience, vacanciesWithoutExperience;

            vacanciesFrom1To3Experience = await _vacanciesRequester.GetVacanciesAsync($"vacancies?text=C%23&schedule=remote&experience=between1And3");
            vacanciesWithoutExperience = await _vacanciesRequester.GetVacanciesAsync($"vacancies?text=C%23&schedule=remote&experience=noExperience");

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("from 1 to 3 years of experience");
            AddVacanciesToStringBuilder(vacanciesFrom1To3Experience, stringBuilder);

            stringBuilder.AppendLine("without experience");
            AddVacanciesToStringBuilder(vacanciesWithoutExperience, stringBuilder);

            var homeFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var vacanciesFolder = $"{homeFolder}/vacancies";
            if (!Directory.Exists(vacanciesFolder))
            {
                Directory.CreateDirectory(vacanciesFolder);
            }
            File.WriteAllText($"{vacanciesFolder}/{DateTime.Now.Date.ToString("dd_MM_yy")}.txt", stringBuilder.ToString());

            await Task.Delay(DAY_IN_MILLISECONDS, stoppingToken);
        }
    }

    private static void AddVacanciesToStringBuilder(IEnumerable<Vacancy> vacanciesFrom1To3Experience, StringBuilder stringBuilder)
    {
        foreach (var vacancy in vacanciesFrom1To3Experience)
        {
            if (!string.IsNullOrWhiteSpace(vacancy.Name))
                stringBuilder.AppendLine(vacancy.Name);
            if (!string.IsNullOrWhiteSpace(vacancy.Url))
                stringBuilder.AppendLine(vacancy.Url);
            if (!string.IsNullOrWhiteSpace(vacancy.AlternateUrl))
                stringBuilder.AppendLine(vacancy.AlternateUrl);
            if (vacancy.Address is not null)
            {
                if (!string.IsNullOrWhiteSpace(vacancy.Address.City))
                    stringBuilder.AppendLine(vacancy.Address.City);
                if (!string.IsNullOrWhiteSpace(vacancy.Address.Street))
                    stringBuilder.AppendLine(vacancy.Address.Street);
                if (!string.IsNullOrWhiteSpace(vacancy.Address.Building))
                    stringBuilder.AppendLine(vacancy.Address.Building);
            }
            if (vacancy.Employer is not null)
            {
                if (!string.IsNullOrWhiteSpace(vacancy.Employer.Name))
                    stringBuilder.AppendLine(vacancy.Employer.Name);
                if (!string.IsNullOrWhiteSpace(vacancy.Employer.Url))
                    stringBuilder.AppendLine(vacancy.Employer.Url);
                if (!string.IsNullOrWhiteSpace(vacancy.Employer.AlternateUrl))
                    stringBuilder.AppendLine(vacancy.Employer.AlternateUrl);
            }
            if (vacancy.Salary is not null)
            {
                if (vacancy.Salary.From.HasValue)
                    stringBuilder.AppendLine(vacancy.Salary.From.Value.ToString());
                if (vacancy.Salary.To.HasValue)
                    stringBuilder.AppendLine(vacancy.Salary.To.ToString());
                if (!string.IsNullOrWhiteSpace(vacancy.Salary.Currency))
                    stringBuilder.AppendLine(vacancy.Salary.Currency);
                stringBuilder.AppendLine(vacancy.Salary.Gross.ToString());
            }
            if (vacancy.Schedule is not null)
            {
                if (!string.IsNullOrWhiteSpace(vacancy.Schedule.Id))
                    stringBuilder.AppendLine(vacancy.Schedule.Id);
                if (!string.IsNullOrWhiteSpace(vacancy.Schedule.Name))
                    stringBuilder.AppendLine(vacancy.Schedule.Name);
            }
            if (vacancy.Snippet is not null)
            {
                if (!string.IsNullOrWhiteSpace(vacancy.Snippet.Requirement))
                    stringBuilder.AppendLine(vacancy.Snippet.Requirement);
                if (!string.IsNullOrWhiteSpace(vacancy.Snippet.Responsibility))
                    stringBuilder.AppendLine(vacancy.Snippet.Responsibility);
            }
        }
    }
}