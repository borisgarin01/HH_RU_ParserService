using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain
{
    public sealed record Salary
    {
        public long Id { get; set; }

        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("from")]
        public int? From { get; set; }

        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("to")]
        public int? To { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonProperty("gross", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("gross")]
        public bool Gross { get; set; }
    }


}