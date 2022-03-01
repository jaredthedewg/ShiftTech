using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ShiftTech.Models
{
    public class CreditCardProvider
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("regex")]
        public string RegEx { get; set; }

    }
}
