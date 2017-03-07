using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class JSONFloat : IValue
    {
        public float val { get; set; }

        public JSONFloat(float val)
        {
            this.val = val;
        }

        public string PrintValue(int indent)
        {
            // Print value of float.
            return val.ToString();
        }
    }
}
