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

        public string PrintValue(int indent)
        {
            // Print each portion of the object, and wrap it.
            string printable = PrintHelper.Indent(indent) + "{\r\n";
            bool atLeastOneEntry = false;
            foreach(string key in fields.Keys)
            {
                IValue content;
                fields.TryGetValue(key, out content);
                printable += PrintHelper.Indent(indent+3) + "\"" + key + "\": " + content.PrintValue(indent+3) + ",\r\n";
                atLeastOneEntry = true;
            }
            if (atLeastOneEntry)
            {
                printable = printable.Substring(0, printable.Length - 3); // Clean ",\r\n" from the end.
                printable += "\r\n" + PrintHelper.Indent(indent) + "}";
            }
            else
            {
                printable += "}";
            }

            return printable;
        }
    }
}
