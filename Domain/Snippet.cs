using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain
{
    public sealed record Snippet
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonProperty("requirement", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("requirement")]
        public string Requirement { get; set; }

        [JsonProperty("responsibility", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("responsibility")]
        public string Responsibility { get; set; }
    }


}