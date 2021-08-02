using System.Collections.Generic;

namespace DalInterfaces
{
    public interface IAutomatChainModellingDAL
    {
        void StartAutomatChainModelling();

        void EndAutomatChainModelling();

        bool DidAutomatWorked(string automatName);

        bool DidPreviousGroupElementsWorked(IEnumerable<string> elemsNameList);

        string CalculateGroupOutputSignal(IEnumerable<string> elemsNameList);

        bool IsChainModellingModeActive();
    }
}
