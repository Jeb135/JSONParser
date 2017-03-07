using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class JSONString : IValue
    {
        public string val { get; set; }

        public JSONString(string val)
        {
            this.val = val;
        }

        public string PrintValue(int indent)
        {
            // Print string
            return "\"" +  val + "\"";
        }
    }
}
