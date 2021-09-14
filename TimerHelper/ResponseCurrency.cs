using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimerHelper
{
    class ResponseCurrency
    {
        [JsonPropertyName("Cur_Name")]
        public string Name { get; set; }
        [JsonPropertyName("Cur_ID")]
        public int Id { get; set; }
        [JsonPropertyName("Cur_OfficialRate")]
        public double Rate { get; set; }
        [JsonPropertyName("Cur_Abbreviation")]
        public string Abbreviation { get; set; }
    }
}
