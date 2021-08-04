using Newtonsoft.Json;
using System.Drawing;

namespace Entities
{
    public class ChainElemViewInfo
    {
        [JsonProperty]
        public string AutomatName { get; private set; }

        [JsonProperty]
        public Point AutomatLocation { get; private set; }


        protected ChainElemViewInfo() { }

        public ChainElemViewInfo(Point location, string name)
        {
            AutomatLocation = location;

            AutomatName = name;
        }
    }
}
