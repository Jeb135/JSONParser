using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class JSONArray : IValue
    {
        public List<IValue> val { get; set; }

        public JSONArray()
        {
            this.val = new List<IValue>();
        }

        public void Add(IValue item)
        {
            // This is a little redundant, consider removing.
            val.Add(item);
        }

        public string PrintValue()
        {
            // Print value of array items.
            return "";
        }
    }
}
