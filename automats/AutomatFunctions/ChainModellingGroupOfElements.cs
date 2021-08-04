using System.Collections.Generic;
using Newtonsoft.Json;

namespace Entities
{
    public class ChainModellingGroupOfElements
    {
        [JsonProperty]
        public int GroupNumber { get; private set; }

        [JsonProperty]
        public List<ChainElemViewInfo> GroupElements { get; private set; }


        protected ChainModellingGroupOfElements() { }

        public ChainModellingGroupOfElements(int groupNum, IEnumerable<ChainElemViewInfo> groupElements)
        {
            GroupNumber = groupNum;

            GroupElements = new List<ChainElemViewInfo>(groupElements);
        }

        public List<string> GetElementNames()
        {
            List<string> result = new List<string>();

            foreach (var item in GroupElements)
            {
                result.Add(item.AutomatName);
            }

            return result;
        }
    }
}
