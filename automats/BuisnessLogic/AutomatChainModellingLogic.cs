using BLInterfaces;
using DalInterfaces;
using System.Collections.Generic;
using CommonConstants;
using System.IO;

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
            if (!DidGroupElemsWork(elementsNames).ValidationPassed())
                return DidGroupElemsWork(elementsNames);

            if (!DidAllPreviousGroupsWork(groupNum))
        }

        public bool DidAutomatWork(string automatName)
        => _DAL.DidAutomatWork(PathConstants.automatChainModellingFolder + Path.DirectorySeparatorChar + automatName + ".json");

        public string DidGroupElemsWork(IEnumerable<string> groupElems)
        {
            foreach (string automatName in groupElems)
                if (!DidAutomatWork(automatName))
                    return automatName + OperationResultIndicators.automatNotWorked;

            return OperationResultIndicators.allOk;
        }

        public bool DidAllPreviousGroupsWork(int currentGroupNum)
        {
            if (currentGroupNum == 1)
                return true;
            else
            {

            }
        }
    }
}
