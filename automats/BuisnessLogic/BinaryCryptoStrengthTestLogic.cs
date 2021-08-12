using System;
using System.Collections.Generic;
using BLInterfaces;
using Entities;
using CommonCollections;
using System.Text;

namespace BuisnessLogic
{
    class BinaryCryptoStrengthTestLogic : ICryptoStrengthTestLogic
    {
        public StrengthTestResultMarks MarkTestResult()
        {
            throw new NotImplementedException();
        }

        public string ParseInputData(string fileName)
        {
            throw new NotImplementedException();
        }

        public ModellingStepData ParseModellingStepResult(List<AutomatConfiguration> data, int stepNumber)
            => new ModellingStepData(ParseCondtions(data), ParseOutputSignals(data), stepNumber);

        string ParseCondtions(List<AutomatConfiguration> data)
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in data)
            {
                result.Append(item.Condition);
            }

            return result.ToString();
        }

        int ParseOutputSignals(List<AutomatConfiguration> data)
        {
            int result = 0;

            int maxDegree = (int)Math.Pow(2, data.Count);

            foreach (var item in data)
            {
                if (item.OutputSignal == "1")
                    result += maxDegree;

                maxDegree /= 2;
            }

            return result;
        }

        public StrengthTestResultMarks TestStart(Automat automat, string inputString, List<string> inputSignalsAlphabet)
        {
            var cicles = new Dictionary<ModellingStepData, ModellingStepData>();

            var modellingStepsStorage = new BinaryTree();

            List<int> conditions = ModellingLogic.GetDistinctStartConditionsSet(automat);

            for (int i = 0; i < inputString.Length; i++)
            {
                List<AutomatConfiguration> iteration = new List<AutomatConfiguration>();

                foreach (var condition in conditions)
                {
                    iteration.Add(ModellingLogic.TactOfWork(inputString.Substring(i, 1), condition, automat,
                        inputSignalsAlphabet.IndexOf(inputString.Substring(i, 1))));
                }

                if (!modellingStepsStorage.Add(ParseModellingStepResult(iteration, i), out ModellingStepData cicle))
                    cicles.Add(cicle, ParseModellingStepResult(iteration, i));

                conditions = UpdateConditionList(iteration);
            }

            return MarkTestResult();
        }

        List<int> UpdateConditionList (List<AutomatConfiguration> modellingIteration)
        {
            List<int> result = new List<int>();

            foreach (var configuration in modellingIteration)
            {
                result.Add(configuration.Condition);
            }

            return result;
        }
    }
}
