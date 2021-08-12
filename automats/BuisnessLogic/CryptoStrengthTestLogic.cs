using System;
using System.Collections.Generic;
using BLInterfaces;
using Entities;
using CommonCollections;

namespace BuisnessLogic
{
    class CryptoStrengthTestLogic : ICryptoStrengthTestLogic
    {
        public StrengthTestResultMarks MarkTestResult()
        {
            throw new NotImplementedException();
        }

        public string ParseInputData(string fileName)
        {
            throw new NotImplementedException();
        }

        public ModellingStepData ParseModellingStepResult(List<AutomatConfiguration> data)
        {
            throw new NotImplementedException();
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

                if (!modellingStepsStorage.Add(ParseModellingStepResult(iteration), out ModellingStepData cicle))
                    cicles.Add(cicle, ParseModellingStepResult(iteration));

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
