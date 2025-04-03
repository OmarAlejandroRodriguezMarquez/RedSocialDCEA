namespace RedSocial.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Character
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("status")]
        public virtual string Status { get; set; }

        [JsonProperty("species")]
        public virtual string Species { get; set; }

        [JsonProperty("type")]
        public virtual string Type { get; set; }

        [JsonProperty("gender")]
        public virtual string Gender { get; set; }

        [JsonProperty("origin")]
        public virtual Location Origin { get; set; }

        [JsonProperty("location")]
        public virtual Location Location { get; set; }

        [JsonProperty("image")]
        public virtual Uri Image { get; set; }

        [JsonProperty("episode")]
        public virtual List<Uri> Episode { get; set; }

        [JsonProperty("url")]
        public virtual Uri Url { get; set; }

        [JsonProperty("created")]
        public virtual DateTimeOffset Created { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("url")]
        public virtual Uri Url { get; set; }
    }

    public partial class Character
    {
        public static Character FromJson(string json) => JsonConvert.DeserializeObject<Character>(json, RedSocial.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Character self) => JsonConvert.SerializeObject(self, RedSocial.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
