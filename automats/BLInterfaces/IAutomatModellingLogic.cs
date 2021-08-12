using Entities;
using System.Collections.Generic;

namespace BLInterfaces
{
    public interface IAutomatModellingLogic
    {
        Dictionary<int, List<AutomatConfiguration>> ModelTheAutomatWork(
            SortedSet<int> startCondtions, List<string> inputSignals, Automat automat, int iterationsNum);

        string CalculateInputSignals(string textToSplit);

        string CalculateOutputSignals(Dictionary<int, List<AutomatConfiguration>> dataToCalculate);

        string CalculateStartConditions(Dictionary<int, List<AutomatConfiguration>> dataToCalculate);

        SortedSet<int> GetDistinctStartConditionsSet(string conditionsString);
    }
}
