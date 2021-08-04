using System.Collections.Generic;

namespace BLInterfaces
{
    public interface IAutomatChainModellingLogic
    {
        bool IsChainModellingModeActive();

        void StartAutomatChainModelling();

        void EndAutomatChainModelling();

        string CalculateGroupOutputSignals(int groupNum, IEnumerable<string> groupElems);

        bool DidAutomatWork(string automatName);

        string DidGroupElemsWork(IEnumerable<string> groupElems);

        string DidAllPreviousGroupsWork(int currentGroupNum);


    }
}
