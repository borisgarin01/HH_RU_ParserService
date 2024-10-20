using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain
{
    public sealed record Employer
    {
        public long Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonProperty("alternate_url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("alternate_url")]
        public string AlternateUrl { get; set; }
        [JsonProperty("vacancies_url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("vacancies_url")]
        public string VacanciesUrl { get; set; }
    }


}