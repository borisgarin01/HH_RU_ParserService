using Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebClients;

public class VacanciesRequester
{
    private readonly HttpClient _httpClient;

    public VacanciesRequester()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        _httpClient.BaseAddress = new Uri("https://api.hh.ru/");
    }
    public async Task<IEnumerable<Vacancy>> GetVacanciesAsync(string query)
    {
        Root root = null;
        var page = 0;
        var vacancies = new List<Vacancy>();
        do
        {
            root = await _httpClient.GetFromJsonAsync<Root>($"{query}&page={page++}");
            vacancies.AddRange(root.Vacancies);
        }
        while (root.Vacancies.Count > 0);
        return vacancies;
    }
}
