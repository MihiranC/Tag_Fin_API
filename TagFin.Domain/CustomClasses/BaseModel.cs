using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagFin.Domain.CustomClasses
{
    public class BaseModel
    {
        public string code { get; set; }
        public string description { get; set; }
        public object data { get; set; }
    }
}
