using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ShiftTech.Models
{
    public class CreditCard
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("card_number")]
        public string CardNumber { get; set; }
    }
}
