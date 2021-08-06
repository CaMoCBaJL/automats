using System.Collections.Generic;
using Entities;

namespace DalInterfaces
{
    public interface IAutomatChainModellingDAL
    {
        void StartAutomatChainModelling();

        void EndAutomatChainModelling();

        bool DidAutomatWork(string fileName);

        bool DidGroupElementsWork(IEnumerable<string> groupElems);

        string CalculateGroupOutputSignal(IEnumerable<string> groupElems);

        bool IsChainModellingModeActive();

        ChainElementSettings GetChainElement(string pathToFile);

        IEnumerable<ChainModellingGroupOfElements> GetElementGroups();

        void SaveAutomatChainConfiguration(IEnumerable<ChainModellingGroupOfElements> chainConfiguration);

        IEnumerable<ChainModellingGroupOfElements> LoadAutomatChainConfiguration();
    }
}
