﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class JSONNull : IValue
    {
        public string PrintValue(int indent)
        {
            // Print null
            return "null";
        }
    }
}
