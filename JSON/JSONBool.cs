using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class JSONBool : IValue
    {
        public bool val { get; set; }

        public JSONBool(bool val)
        {
            this.val = val;
        }

        public string PrintValue()
        {
            // Print value of bool.
            return "";
        }
    }
}
