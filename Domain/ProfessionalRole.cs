using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain
{
    public sealed record ProfessionalRole
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }


}