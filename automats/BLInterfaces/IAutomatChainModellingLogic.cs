using Entities;
using System.Collections.Generic;
using System.Drawing;

namespace BLInterfaces
{
    public interface IAutomatChainModellingLogic
    {
        bool IsChainModellingModeActive();

        void StartAutomatChainModelling();

        void EndAutomatChainModelling();

        string CalculateAutomatInputSignals(string automatName);

        bool DidAutomatWork(string automatName);

        string DidGroupElemsWork(IEnumerable<string> groupElems);

        string DidAllPreviousGroupsWork(int currentGroupNum);

        int GetAutomatGroup(string automatName);

        List<ChainModellingGroupOfElements> DivideAutomatByGroups(Dictionary<string, Point> dataToDivision);

        void SaveAutomatChainAppearance(Dictionary<string, Point> nameAndLocationPair);

        Dictionary<string, Point> LoadAutomatChainAppearance();

        List<ChainModellingGroupOfElements> LoadAutomatGroups();
    }
}
