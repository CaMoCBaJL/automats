using Entities;
using System.Collections.Generic;

namespace BLInterfaces
{
    public interface ICryptoStrengthTestLogic
    {
        string ParseInputData(string fileName);

        StrengthTestResultMarks MarkTestResult();

        ModellingStepData ParseModellingStepResult(List<AutomatConfiguration> data);

        StrengthTestResultMarks TestStart(Automat automat, string inputString, List<string> inputSignalsAlphabet);
    }
}
