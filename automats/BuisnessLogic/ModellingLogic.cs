using System.Collections.Generic;
using Entities;
using System.Linq;
using BLInterfaces;
using System;
using System.Text;
using CommonConstants;

namespace BuisnessLogic
{
    public class ModellingLogic : IAutomatModellingLogic
    {
        public Dictionary<int, List<AutomatConfiguration>> ModelTheAutomatWork(
            SortedSet<int> startCondtions, List<string> inputSignals, Automat automat, int iterationsNum)
        {
            Dictionary<int, List<AutomatConfiguration>> result = new Dictionary<int, List<AutomatConfiguration>>();

            List<string> inputSignalsCollection = GetInputSignalsCollection(inputSignals).Cast<string>().ToList<string>();

            AddFirstConfigurations(ref result, startCondtions);

            for (int iterCounter = 0; iterCounter < iterationsNum; iterCounter++)
            {
                if (iterCounter > 0)
                    inputSignals = ConstructStartData(result).outputSignals;
                
                for (int i = 0; i < inputSignals.Count; i++)
                {
                    foreach (var condition in result.Keys)
                    {
                        result[condition].Add(TactOfWork(inputSignals[i], result[condition][result[condition].Count - 1].Condition - 1,
                            automat, inputSignalsCollection.IndexOf(inputSignals[i])));
                    }
                }
            }

            return result;
        }

        void AddFirstConfigurations(ref Dictionary<int, List<AutomatConfiguration>> result, SortedSet<int> startConditions)
        {
            foreach (int condition in startConditions)
            {
                result.Add(condition, new List<AutomatConfiguration>());

                result[condition].Add(new AutomatConfiguration("-", condition, "-"));
            }
        }

        internal static AutomatConfiguration TactOfWork(string inputSignal, int condition, Automat automat, int inputSignalNum)
            => new AutomatConfiguration(inputSignal,

                Automat.AutomatFunction(automat.DeltaTable, condition, inputSignalNum),

                Automat.AutomatFunction(automat.LambdaTable, condition, inputSignalNum));

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

        public string CalculateInputSignals(string textToSplit)
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in textToSplit.Split(SplitTemplates.spaceToSplit, StringSplitOptions.RemoveEmptyEntries))
            {
                result.Append(item);
            }

            return result.ToString();
        }

        public string CalculateOutputSignals(Dictionary<int, List<AutomatConfiguration>> dataToCalculate)
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in dataToCalculate.Values)
            {
                item.ForEach((configuration) =>
                {
                    if (configuration.OutputSignal != "-")
                        result.Append(configuration.OutputSignal + " ");
                });
            }

            return result.ToString();
        }

        internal static List<int> GetDistinctStartConditionsSet(Automat automat)
            => new SortedSet<int>(automat.DeltaTable.Cast<int>()).ToList();

        public SortedSet<int> GetDistinctStartConditionsSet(string conditionsString)
        {
            SortedSet<int> result = new SortedSet<int>();

            foreach (var item in conditionsString.Split(SplitTemplates.spaceToSplit, StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(int.Parse(item));
            }

            return result;
        }

        public string CalculateStartConditions(Dictionary<int, List<AutomatConfiguration>> dataToCalculate)
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in dataToCalculate.Values)
            {
                item.ForEach((configuration) =>
                {
                    if (configuration.OutputSignal == "-")
                        result.Append(configuration.Condition + " ");
                });
            }

            return result.ToString();
        }
    }
}
