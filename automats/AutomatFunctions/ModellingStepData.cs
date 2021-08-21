using Newtonsoft.Json;

namespace Entities
{
    public class ModellingStepData
    {
        [JsonProperty]
        public string Conditions { get; private set; }

        [JsonProperty]
        public int StepNumber { get; private set; }


        public ModellingStepData() { }

        public ModellingStepData(string conditions, int stepNumber)
        {
            Conditions = conditions;

            StepNumber = stepNumber;
        }
    }
}
