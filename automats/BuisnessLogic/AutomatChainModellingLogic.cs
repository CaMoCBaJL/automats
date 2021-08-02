using BLInterfaces;
using DalInterfaces;
using System.Collections.Generic;

namespace BuisnessLogic
{
    public class AutomatChainModellingLogic : IAutomatChainModellingLogic
    {
        IAutomatChainModellingDAL _DAL;

        public AutomatChainModellingLogic(IAutomatChainModellingDAL dal) => _DAL = dal;


        public void StartAutomatChainModelling()
        => _DAL.StartAutomatChainModelling();

        public void EndAutomatChainModelling()
        => _DAL.EndAutomatChainModelling();

        public string CalculateGroupOutputSignals(int groupNum, IEnumerable<string> elementsNames)
        {
            throw new System.NotImplementedException();
        }

        public bool DidAutomatWorked(string automatName)
        {
            throw new System.NotImplementedException();
        }

        public string DidPreviousGroupElemsWorked(IEnumerable<string> elementsNames)
        {
            throw new System.NotImplementedException();
        }
    }
}
