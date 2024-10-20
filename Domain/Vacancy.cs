using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain
{
    public sealed record Vacancy
    {
        public string Id { get; set; }
        [JsonProperty("premium", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("premium")]
        public bool Premium { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("has_test", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("has_test")]
        public bool HasTest { get; set; }

        [JsonProperty("response_letter_required", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("response_letter_required")]
        public bool ResponseLetterRequired { get; set; }

        [JsonProperty("area", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("area")]
        public Area Area { get; set; }

        public string AreaId { get; set; }

        [JsonProperty("salary", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("salary")]
        public Salary Salary { get; set; }

        public long SalaryId { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public Type Type { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonProperty("archived", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonProperty("apply_alternate_url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("apply_alternate_url")]
        public string ApplyAlternateUrl { get; set; }

        [JsonProperty("show_logo_in_search", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("show_logo_in_search")]
        public bool? ShowLogoInSearch { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonProperty("alternate_url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("alternate_url")]
        public string AlternateUrl { get; set; }

        [JsonProperty("employer", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("employer")]
        public Employer Employer { get; set; }

        public long EmployerId { get; set; }

        [JsonProperty("snippet", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("snippet")]
        public Snippet Snippet { get; set; }

        public long SnippetId { get; set; }

        [JsonProperty("schedule", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("schedule")]
        public Schedule Schedule { get; set; }

        [JsonProperty("accept_temporary", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("accept_temporary")]
        public bool AcceptTemporary { get; set; }

        [JsonProperty("professional_roles", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("professional_roles")]
        public List<ProfessionalRole> ProfessionalRoles { get; set; }

        [JsonProperty("accept_incomplete_resumes", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("accept_incomplete_resumes")]
        public bool AcceptIncompleteResumes { get; set; }

        [JsonProperty("experience", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("experience")]
        public Experience Experience { get; set; }

        [JsonProperty("employment", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("employment")]
        public Employment Employment { get; set; }

        [JsonProperty("is_adv_vacancy", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_adv_vacancy")]
        public bool IsAdvVacancy { get; set; }

        [JsonProperty("branding", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("branding")]
        public Branding Branding { get; set; }
    }


}