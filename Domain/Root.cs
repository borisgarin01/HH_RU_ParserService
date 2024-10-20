using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public sealed record Root
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("items")]
        public List<Vacancy> Vacancies { get; set; }

        [JsonProperty("found", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("found")]
        public int Found { get; set; }

        [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("pages")]
        public int Pages { get; set; }

        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonProperty("per_page", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("alternate_url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("alternate_url")]
        public string AlternateUrl { get; set; }
    }


}