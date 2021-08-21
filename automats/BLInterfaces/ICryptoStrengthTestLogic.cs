using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLInterfaces
{
    public interface ICryptoStrengthTestLogic
    {
        string ParseInputData(string fileName);

        StrengthTestResultMarks MarkTestResult(Dictionary<ModellingStepData, ModellingStepData> cyclesData, string inputString);

        KeyValuePair<int, ModellingStepData> ParseModellingStepResult(List<AutomatConfiguration> data, int stepNumber);

        void CheckTestDataStorageExistence();

        void EndTest();

        KeyValuePair<ModellingStepData, ModellingStepData> LoadNewCycleData(string pathToData);

        Task<StrengthTestResultMarks> StartTest(Automat automat, string inputString, List<string> inputSignalsAlphabet);

        bool SaveExecutionData(ModellingStepData firstStep, ModellingStepData secondStep);

        Dictionary<ModellingStepData, ModellingStepData> LoadExecutionData();

        int GetExecutionStep();
    }
}
