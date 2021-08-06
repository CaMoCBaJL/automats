using Newtonsoft.Json;

namespace Entities
{
    public class ChainElementSettings
    {
        [JsonProperty]
        public string StartConditionSet { get; private set; }

        [JsonProperty]
        public string AutomatDataFile { get; private set; }
        
        [JsonProperty]
        public string InputSignalString { get; private set; }

        [JsonProperty]
        public string OutputSignalString { get; private set; }

        [JsonProperty]
        public string AutomatName { get; private set; }

        protected ChainElementSettings() { }

        public ChainElementSettings(string automatTablesDataFileName, string inputSignalString, string outputSignalString, string automatName,
            string startConditions)
        {
            StartConditionSet = startConditions;

            AutomatDataFile = automatTablesDataFileName;

            InputSignalString = inputSignalString;

            OutputSignalString = outputSignalString;

            AutomatName = automatName;
        }
    }
}
