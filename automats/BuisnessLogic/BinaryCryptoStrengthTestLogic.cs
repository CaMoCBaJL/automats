using System;
using System.Collections.Generic;
using BLInterfaces;
using Entities;
using System.Text;
using DataAccessLayer;
using DalInterfaces;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class BinaryCryptoStrengthTestLogic : ICryptoStrengthTestLogic
    {
        ICryptoStrengthTestDataTransmitterDAL _DAL;

        public BinaryCryptoStrengthTestLogic(ICryptoStrengthTestDataTransmitterDAL dal) => _DAL = dal;


        int ExecutionStep { get; set; }

        public string ParseInputData(string fileName)
            => new DataProvidingLogic(new DataIntegrityDAL()).ReadAllBytesFromFile(fileName);

        public KeyValuePair<int, ModellingStepData> ParseModellingStepResult(List<AutomatConfiguration> data, int stepNumber)
            => new KeyValuePair<int, ModellingStepData>(ParseOutputSignals(data), new ModellingStepData(ParseCondtions(data), stepNumber));

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

            int maxDegree = (int)Math.Pow(2, data.Count - 1);

            foreach (var item in data)
            {
                if (item.OutputSignal == "1")
                    result += maxDegree;

                maxDegree /= 2;
            }

            return result;
        }

        public async Task<StrengthTestResultMarks> StartTest(Automat automat, string inputString, List<string> inputSignalsAlphabet)
        {
            var result = await Task.Run(() => StrengthTest(automat, inputString, inputSignalsAlphabet));

            return result;
        }

        StrengthTestResultMarks StrengthTest(Automat automat, string inputString, List<string> inputSignalsAlphabet)
        {
            var cycles = new Dictionary<ModellingStepData, ModellingStepData>();

            var modellingStepsStorage = new SortedList<int, ModellingStepData>();

            List<int> conditions = ModellingLogic.GetDistinctStartConditionsSet(automat);

            for (int i = 0; i < inputString.Length; i++)
            {
                ExecutionStep = i;

                List<AutomatConfiguration> modellingStep = new List<AutomatConfiguration>();

                foreach (var condition in conditions)
                {
                    modellingStep.Add(ModellingLogic.TactOfWork(inputString.Substring(i, 1), condition - 1, automat,
                        inputSignalsAlphabet.IndexOf(inputString.Substring(i, 1))));
                }

                var newData = ParseModellingStepResult(modellingStep, i);

                if (modellingStepsStorage.ContainsKey(newData.Key))
                {
                    if (modellingStepsStorage[newData.Key].Conditions == newData.Value.Conditions)
                    {
                        cycles.Add(modellingStepsStorage[newData.Key], newData.Value);

                        _DAL.SaveExecutionData(modellingStepsStorage[newData.Key], newData.Value);
                    }

                    modellingStepsStorage.Remove(newData.Key);
                }

                modellingStepsStorage.Add(newData.Key, newData.Value);

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

        public bool SaveExecutionData(ModellingStepData firstStep, ModellingStepData secondStep)
        => _DAL.SaveExecutionData(firstStep, secondStep);

        public Dictionary<ModellingStepData, ModellingStepData> LoadExecutionData()
        => _DAL.LoadExecutionData();

        public KeyValuePair<ModellingStepData, ModellingStepData> LoadNewCycleData(string pathTofile)
            => _DAL.LoadNewCycleData(pathTofile);

        public int GetExecutionStep()
        => ExecutionStep;

        public void CheckTestDataStorageExistence()
        => _DAL.CheckDataFolderIntegrity();

        public void EndTest()
        => _DAL.EndCryptoStrengthTest();
    }
}
