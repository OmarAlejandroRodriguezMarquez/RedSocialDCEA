namespace RedSocial.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CatGenero
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }

        [JsonProperty("nombreGenero")]
        public virtual string NombreGenero { get; set; }
    }

    public partial class CatGenero
    {
        public static List<CatGenero> FromJson(string json) => JsonConvert.DeserializeObject<List<CatGenero>>(json, RedSocial.Models.Converter.Settings);
    }

    public static class SerializeG
    {
        public static string ToJson(this List<CatGenero> self) => JsonConvert.SerializeObject(self, RedSocial.Models.Converter.Settings);
    }

    internal static class ConverterG
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