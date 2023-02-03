using Newtonsoft.Json;
using System.IO;

namespace RESTSimulator.Data
{
    public class Appendix
    {
        public string[] FirstNames;
        public string[] LastNames;

        public Appendix()
        {
            string firstNames = File.ReadAllText("data\\firstNames.json");
            string lastNames = File.ReadAllText("data\\lastNames.json");

            if (!string.IsNullOrEmpty(firstNames))
                FirstNames = JsonConvert.DeserializeObject<string[]>(firstNames);

            if (!string.IsNullOrEmpty(lastNames))
                LastNames = JsonConvert.DeserializeObject<string[]>(lastNames);
        }
    }
}
