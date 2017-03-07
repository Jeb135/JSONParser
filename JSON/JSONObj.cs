using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class JSONObj : IValue
    {
        public Dictionary<string, IValue> fields { get; set; }

        public JSONObj()
        {
            this.fields = new Dictionary<string, IValue>();
        }

        public void Add(string name, IValue contents)
        {
            // This is a little redundant. Consider removing.
            fields.Add(name, contents);
        }

        public string PrintValue()
        {
            // Print each portion of the object, and wrap it.
            return "";
        }
    }
}
