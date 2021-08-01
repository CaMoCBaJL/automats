using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutomatFunctions
{
    class ChainElementSettings
    {
        [JsonProperty]
        public string AutomatDataFile { get; private set; }
        
        [JsonProperty]
        public string InputSignalString { get; private set; }

        [JsonProperty]
        public string OutputSignalString { get; private set; }


        protected ChainElementSettings() { }


    }
}
