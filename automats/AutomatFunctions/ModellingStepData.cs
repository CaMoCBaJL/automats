namespace Entities
{
    public class ModellingStepData
    {
        public string Conditions { get; }

        public int OutputSignals { get; }

        public int StepNumber { get; }


        public ModellingStepData() { }

        public ModellingStepData(string conditions, int outputSignals, int stepNumber)
        {
            Conditions = conditions;

            OutputSignals = outputSignals;

            StepNumber = stepNumber;
        }
    }
}
