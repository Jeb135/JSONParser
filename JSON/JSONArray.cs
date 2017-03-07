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

        public string PrintValue(int indent)
        {
            // Print value of array items.
            string printable = PrintHelper.Indent(indent) + "[\r\n";
            bool atLeastOneEntry = false;
            foreach (IValue item in val)
            {
                printable += PrintHelper.Indent(indent + 3) + item.PrintValue(indent + 3) + ",\r\n";
            }
            if (atLeastOneEntry)
            {
                printable = printable.Substring(0, printable.Length - 3); // Clean ",\r\n" from the end.
                printable += "\r\n" + PrintHelper.Indent(indent) + "]";
            }
            else
            {
                printable += "]";
            }
            return printable;
        }
    }
}
