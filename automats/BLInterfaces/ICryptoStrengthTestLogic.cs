using Entities;
using System.Collections.Generic;

namespace BLInterfaces
{
    public interface ICryptoStrengthTestLogic
    {
        string ParseInputData(string fileName);

        StrengthTestResultMarks MarkTestResult(Dictionary<ModellingStepData, ModellingStepData> cyclesData, string inputString);

        ModellingStepData ParseModellingStepResult(List<AutomatConfiguration> data, int stepNumber);

        StrengthTestResultMarks TestStart(Automat automat, string inputString, List<string> inputSignalsAlphabet);
    }
}
