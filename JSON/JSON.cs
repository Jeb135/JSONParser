using System;

namespace JSON
{
    class JSON
    {
        static void Main(string[] args)
        {
            string website = "http://reddit.com/r/front.json";
            if(args.Length > 0)
            {
                website = args[0];
                Console.WriteLine("Parsing JSON object from \"" + website + "\"");
            }
            System.Net.WebClient client = new System.Net.WebClient();
            byte[] raw = client.DownloadData(website);
            string rawtext = System.Text.Encoding.UTF8.GetString(raw);

            // Hardcoded Test string.
            //rawtext = "{ \"name\":\"John\", \"age\":30, \"car\":null, \"Ted\":false, \"cars\": {\"car1\":\"Ford\", \"car2\":\"BMW\", \"car3\":\"Fiat\"}, \"morecars\":[ \"Ford\", \"BMW\", \"Fiat\" ]}";
            JSONParser parser = new JSONParser(rawtext);
            Console.WriteLine("Sucessfully parsed JSON object with a weight of " + parser.weight);
            // This currently does nothing right now.
            string printable = parser.Pretty_Print();

            // Test the printer for correctness.
            // Uncommenting the below line throws an error.
            //JSONParser printTest = new JSONParser(printable);

            // Uncomment to print the json object. (currently invalid, however.)
            //Console.WriteLine(printable);
        }
    }
}
