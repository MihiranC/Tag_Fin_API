using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TagFin.Domain.CustomClasses
{
    public class UpdateData
    {
        public int UserID { get; set; }
        [JsonPropertyName("newData")]
        public JsonElement NewData { get; set; }
        [JsonPropertyName("OldData")]
        public JsonElement OldData { get; set; }
    }
}
