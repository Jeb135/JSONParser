using System;

namespace JSON
{
    class JSON
    {
        static void Main(string[] args)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            byte[] raw = client.DownloadData("http://reddit.com/r/front.json");
            string rawtext = System.Text.Encoding.UTF8.GetString(raw);

            // Hardcoded Test string.
            //string rawtext = "{ \"name\":\"John\", \"age\":30, \"car\":null, \"Ted\":false, \"cars\": {\"car1\":\"Ford\", \"car2\":\"BMW\", \"car3\":\"Fiat\"}, \"morecars\":[ \"Ford\", \"BMW\", \"Fiat\" ]}";
            JSONParser parser = new JSONParser(rawtext);
            
            // This currently does nothing right now.
            Console.WriteLine(parser.Pretty_Print());
        }
    }
}
