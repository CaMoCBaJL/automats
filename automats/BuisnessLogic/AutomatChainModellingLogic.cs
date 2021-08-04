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

            if (!DidAllPreviousGroupsWork(groupNum).ValidationPassed())
                return DidAllPreviousGroupsWork(groupNum);

            return _DAL.CalculateGroupOutputSignal(elementsNames);
        }

        public bool DidAutomatWork(string automatName)
        => _DAL.DidAutomatWork(PathConstants.automatChainModellingFolder + Path.DirectorySeparatorChar + automatName + ".json");

        public string DidGroupElemsWork(IEnumerable<string> groupElems)
        {
            foreach (var elem in groupElems)
                if (!DidAutomatWork(elem))
                    return elem + OperationResultIndicators.automatNotWorked;

            return OperationResultIndicators.allOk;
        }

        public string DidAllPreviousGroupsWork(int currentGroupNum)
        {
            if (currentGroupNum == 1)
                return OperationResultIndicators.allOk;
            else
            {
                foreach (var group in _DAL.GetElementGroups())
                {
                    if (group.GroupNumber <= currentGroupNum)
                    {
                        if (!DidGroupElemsWork(group.GetElementNames()).ValidationPassed())
                            return DidGroupElemsWork(group.GetElementNames());
                    }

                    else
                        return OperationResultIndicators.allOk;
                }
            }

            return OperationResultIndicators.errorMessage;
        }

        public bool IsChainModellingModeActive()
        => _DAL.IsChainModellingModeActive();
    }
}
