namespace Entities
{
    public class AutomatConfiguration
    {
        public int Condition { get; set; }

        public string OutputSignal { get; set; }

        public string InputSignal { get; set; }


        public AutomatConfiguration(string inputSignal, int condition, string outputSignal)
        {
            Condition = condition;

            InputSignal = inputSignal;

            OutputSignal = outputSignal;
        }

        public override string ToString()
            => $"{Condition} {OutputSignal} {InputSignal}";

    }
}
