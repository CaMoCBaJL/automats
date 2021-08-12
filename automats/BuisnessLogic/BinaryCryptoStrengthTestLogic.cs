using System;
using System.Collections.Generic;
using BLInterfaces;
using Entities;
using CommonCollections;
using System.Text;
using DataAccessLayer;

namespace BuisnessLogic
{
    class BinaryCryptoStrengthTestLogic : ICryptoStrengthTestLogic
    {
        public string ParseInputData(string fileName)
            => new DataProvidingLogic(new DataIntegrityDAL()).ReadAllBytesFromFile(fileName);

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
            var cycles = new Dictionary<ModellingStepData, ModellingStepData>();

            var modellingStepsStorage = new BinaryTree();

            List<int> conditions = ModellingLogic.GetDistinctStartConditionsSet(automat);

            for (int i = 0; i < inputString.Length; i++)
            {
                List<AutomatConfiguration> modellingStep = new List<AutomatConfiguration>();

                foreach (var condition in conditions)
                {
                    modellingStep.Add(ModellingLogic.TactOfWork(inputString.Substring(i, 1), condition, automat,
                        inputSignalsAlphabet.IndexOf(inputString.Substring(i, 1))));
                }

                if (!modellingStepsStorage.Add(ParseModellingStepResult(modellingStep, i), out ModellingStepData cicle))
                    cycles.Add(cicle, ParseModellingStepResult(modellingStep, i));

                conditions = UpdateConditionList(modellingStep);
            }

            return MarkTestResult(cycles, inputString);
        }

        List<int> UpdateConditionList(List<AutomatConfiguration> modellingIteration)
        {
            List<int> result = new List<int>();

            foreach (var configuration in modellingIteration)
            {
                result.Add(configuration.Condition);
            }

            return result;
        }

        public StrengthTestResultMarks MarkTestResult(Dictionary<ModellingStepData, ModellingStepData> cycles, string inputString)
        => DefineTestResultByRate(RateTestResult(cycles, inputString));

        double RateTestResult(Dictionary<ModellingStepData, ModellingStepData> cycles, string inputString)
        {
            double mark = 0;

            foreach (var cycle in cycles)
            {
                mark += (cycle.Value.StepNumber - cycle.Key.StepNumber) / inputString.Length;
            }

            return mark / cycles.Count;
        }

        StrengthTestResultMarks DefineTestResultByRate(double rate)
        {
            if (rate > 1)
                return StrengthTestResultMarks.None;
            else if (rate <= 1 && rate > 0.9)
                return StrengthTestResultMarks.Excellent;
            else if (rate <= 0.9 && rate > 0.75)
                return StrengthTestResultMarks.Good;
            else if (rate <= 0.75 && rate > 0.55)
                return StrengthTestResultMarks.Satisfactory;
            else if (rate <= 0.55 && rate > 0.3)
                return StrengthTestResultMarks.Unsatisfactory;

            return StrengthTestResultMarks.Bad;
        }
    }
}
