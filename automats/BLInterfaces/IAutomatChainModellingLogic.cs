using System.Collections.Generic;

namespace BLInterfaces
{
    public interface IAutomatChainModellingLogic
    {
        void StartAutomatChainModelling();

        void EndAutomatChainModelling();

        string CalculateGroupOutputSignals(int groupNum, IEnumerable<string> elementsNames);

        bool DidAutomatWorked(string automatName);

        string DidPreviousGroupElemsWorked(IEnumerable<string> elementsNames);
    }
}
