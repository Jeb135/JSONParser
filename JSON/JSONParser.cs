using System;

namespace JSON
{
    class JSONParser
    {
        private static string InvalidJSONError = "Error, invalid JSON.";
        public JSONObj root { get; set; }
        public int weight { get; set; }

        public JSONParser(string text)
        {
            text = RemoveWhiteSpace(text);
            if(text[0] == '{')
            {
                root = (JSONObj)this.Parse(ref text); // enforce this better somehow?
            }
            else
            {
                throw new Exception(InvalidJSONError);
            }
            
        }

        private IValue Parse(ref string text)
        {
            // This is where the workhorse is.
            IValue item;
            text = RemoveWhiteSpace(text);
            switch (text[0])
            {
                case '{':
                    // Object Case.
                    item = ParseObject(ref text);
                    break;
                case '[':
                    // Array Case.
                    item = ParseArray(ref text);
                    break;
                case 'n':
                    // Null case.
                    item = ParseNull(ref text);
                    break;
                case 't':
                case 'f':
                    // True/False case.
                    item = ParseBool(ref text);
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    // Floating Point number case.
                    item = ParseFloat(ref text);
                    break;
                case '"':
                    // String case.
                    item = ParseString(ref text);
                    break;
                default:
                    // Error case.
                    throw new Exception(InvalidJSONError);
            }
            text = RemoveWhiteSpace(text);

            return item;
        }

        private string RemoveWhiteSpace(string text)
        {
            if(text == string.Empty)
            {
                return text;
            }
            while(text[0] == ' ' || text[0] == '\n' || text[0] == '\r')
            {
                text = text.Substring(1);   // slices off the fisrt character in the string.
            }
            return text;
        }

        private JSONObj ParseObject(ref string text)
        {
            JSONObj item = new JSONObj();
            // Remove the '{'
            text = text.Substring(1);

            bool doneParsingObj = false;
            while (!doneParsingObj)
            {
                text = RemoveWhiteSpace(text);
                if (text[0] == '}')
                {
                    // End of Object.
                    // This is an edge case.
                    text = text.Substring(1);
                    doneParsingObj = true; // break from loop.
                }
                else
                {
                    string name = "";
                    IValue contents = null;
                    // get the name of the next item in the object.
                    name = GrabQuotedString(ref text);

                    // get rid of the colon. 
                    text = RemoveWhiteSpace(text); // In case of space before colon.
                    if(text[0] == ':')
                    {
                        // Remove Colon.
                        text = text.Substring(1);
                    }
                    else
                    {
                        // If something strange happens.
                        throw new Exception(InvalidJSONError);
                    }

                    // Parse the contents.
                    contents = Parse(ref text);
                    
                    // Add item to object.
                    item.Add(name, contents);

                    //Check for comma or }, end loop if necessary.
                    if(text[0] == ',')
                    {
                        text = text.Substring(1);
                        text = RemoveWhiteSpace(text);
                    }
                    else if(text[0] == '}')
                    {
                        doneParsingObj = true;
                        text = text.Substring(1);
                        text = RemoveWhiteSpace(text);
                    }
                    else
                    {
                        // Invalid JSON in this case. Throw error.
                        throw new Exception(InvalidJSONError);
                    }
                        
                }
            }
            weight++;
            return item;
        }

        private JSONArray ParseArray(ref string text)
        {
            JSONArray item = new JSONArray();
            // Remove the '['
            text = text.Substring(1);

            bool doneParsingObj = false;
            while (!doneParsingObj)
            {
                text = RemoveWhiteSpace(text);
                if (text[0] == ']')
                {
                    // End of Object.
                    // This is an edge case.
                    text = text.Substring(1);
                    doneParsingObj = true; // break from loop.
                }
                else
                {
                    IValue contents = null;

                    // Parse the contents.
                    contents = Parse(ref text);

                    // Add item to object.
                    item.Add(contents);

                    //Check for comma or }, end loop if necessary.
                    if (text[0] == ',')
                    {
                        text = text.Substring(1);
                        text = RemoveWhiteSpace(text);
                    }
                    else if (text[0] == ']')
                    {
                        doneParsingObj = true;
                        text = text.Substring(1);
                        text = RemoveWhiteSpace(text);
                    }
                    else
                    {
                        // Invalid JSON in this case. Throw error.
                        throw new Exception(InvalidJSONError);
                    }

                }
            }
            weight++;
            return item;
        }

        private JSONNull ParseNull(ref string text)
        {
            JSONNull item = new JSONNull();
            text = text.Substring(4);    // remove null
            weight++;
            return item;
        }

        private JSONBool ParseBool(ref string text)
        {
            JSONBool item;
            if(text[0] == 't')
            {
                item = new JSONBool(true);
                text = text.Substring(4);
            }
            else
            {
                item = new JSONBool(false);
                text = text.Substring(5);
            }
            weight++;
            return item;
        }

        private JSONFloat ParseFloat(ref string text)
        {
            int indexOfComma = text.IndexOf(",", 0);
            int indexOfBrace = text.IndexOf("}", 0);
            int indexOfBracket = text.IndexOf("]", 0);
            string numstring = text.Substring(0, Math.Min(indexOfComma, Math.Min(indexOfBrace, indexOfBracket)));
            text = text.Substring(Math.Min(indexOfComma, Math.Min(indexOfBrace, indexOfBracket)));
            JSONFloat item = new JSONFloat(float.Parse(numstring));
            weight++;
            return item;
        }

        private JSONString ParseString(ref string text)
        {
            JSONString item = new JSONString(GrabQuotedString(ref text));
            weight++;
            return item;
        }

        private string GrabQuotedString(ref string text)
        {
            // Grab a string at the begining of text in the form of "geuhguaga" WITHOUT quotes.
            bool found = false;
            int length = 2;
            int startSearchIndex = 1;
            while (!found)
            {
                length = text.IndexOf("\"", startSearchIndex);
                char before = text[length - 1];
                if (text[length - 1] == '\\')
                {
                    startSearchIndex = length + 1;
                }
                else
                {
                    found = true;
                }
            }
            //int length = text.IndexOf("\"", 1);
            string quoted = text.Substring(1, length-1);
            text = text.Substring(length + 1);
            return quoted;
        }

        public string Pretty_Print()
        {
            return root.PrintValue(0);
        }
    }
}
