using System.Collections.Generic;
using Entities;
using System.Linq;
using BLInterfaces;

namespace BuisnessLogic
{
    public class ModellingLogic : IAutomatModellingLogic
    {
        public Dictionary<int, List<AutomatConfiguration>> ModelTheAutomatWork(
            List<int> startCondtions, List<string> inputSignals, Automat automat, int iterationsNum)
        {
            Dictionary<int, List<AutomatConfiguration>> result = new Dictionary<int, List<AutomatConfiguration>>();

            List<string> inputSignalsCollection = GetInputSignalsCollection(inputSignals).Cast<string>().ToList<string>();

            foreach (int condition in startCondtions)
            {
                result.Add(condition, new List<AutomatConfiguration>());

                result[condition].Add(new AutomatConfiguration("-", condition, "-"));
            }

            for (int iterCounter = 0; iterCounter < iterationsNum + 1; iterCounter++)
            {
                if (iterCounter > 0)
                {
                    var data = ConstructStartData(result);

                    inputSignals = data.outputSignals;

                    startCondtions = data.conditions;
                }

                for (int i = 0; i < inputSignals.Count; i++)
                {
                    foreach (var condition in result.Keys)
                    {
                        result[condition].Add(new AutomatConfiguration(inputSignals[i],

                            Automat.AutomatFunction<int>(automat.DeltaTable, result[condition][result[condition].Count - 1].Condition - 1,
                            inputSignalsCollection.IndexOf(inputSignals[i])),

                            Automat.AutomatFunction<string>(automat.LambdaTable, result[condition][result[condition].Count - 1].Condition - 1,
                            inputSignalsCollection.IndexOf(inputSignals[i]))));
                    }
                }
            }

            return result;
        }

        (List<int> conditions, List<string> outputSignals) ConstructStartData(Dictionary<int, List<AutomatConfiguration>> data)
        {
            List<int> conditions = new List<int>();

            List<string> outputSignals = new List<string>();

            foreach (var pair in data)
            {
                conditions.Add(pair.Value.Last().Condition);

                foreach (var elem in pair.Value)
                {
                    if (elem.OutputSignal != "-")
                        outputSignals.Add(elem.OutputSignal);
                }
            }

            return (conditions, outputSignals);
        }

        SortedSet<string> GetInputSignalsCollection(List<string> inputSignals)
        {
            SortedSet<string> uniqueSignals = new SortedSet<string>();

            foreach (var signal in inputSignals)
            {
                if (!uniqueSignals.Contains(signal))
                    uniqueSignals.Add(signal);
            }

            return uniqueSignals;
        }
    }
}
