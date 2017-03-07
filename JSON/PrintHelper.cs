using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    static class PrintHelper
    {
        public static string Indent(int indent)
        {
            return new string(' ', indent);
        }
    }
}
