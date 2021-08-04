using Entities;
using System.Collections.Generic;

namespace BLInterfaces
{
    public interface IAutomatModellingLogic
    {
        Dictionary<int, List<AutomatConfiguration>> ModelTheAutomatWork(
            List<int> startCondtions, List<string> inputSignals, Automat automat, int iterationsNum);

        string CalculateInputSignals(string textToSplit);

        string CalculateOutputSignals(Dictionary<int, List<AutomatConfiguration>> dataToCalculate);

        List<int> GetDistinctStartConditionsSet(string conditionsString);
    }
}
