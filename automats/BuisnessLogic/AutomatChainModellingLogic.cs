using BLInterfaces;
using DalInterfaces;
using System.Collections.Generic;
using CommonConstants;
using System.IO;
using System.Drawing;
using Entities;
using System;
using System.Linq;
using DataValidation;

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

        public bool DidAutomatWork(string automatName)
        => _DAL.DidAutomatWork(PathConstants.automatChainModellingFolder + Path.DirectorySeparatorChar + automatName + ".json");

        public string DidGroupElemsWork(IEnumerable<string> groupElems)
        {
            foreach (var elem in groupElems)
                if (!DidAutomatWork(elem))
                    return elem + StringIndicators.automatNotWorked;

            return StringIndicators.allOk;
        }

        public string DidAllPreviousGroupsWork(int currentGroupNum)
        {
            if (currentGroupNum == 1)
                return StringIndicators.allOk;
            else
            {
                foreach (var group in _DAL.GetElementGroups())
                {
                    if (group.GroupNumber < currentGroupNum)
                    {
                        if (!DidGroupElemsWork(group.GetElementNames()).ValidationPassed())
                            return DidGroupElemsWork(group.GetElementNames());
                    }

                    else
                        return StringIndicators.allOk;
                }
            }

            return StringIndicators.errorMessage;
        }

        public Dictionary<string, Point> LoadAutomatChainAppearance()
        {
            Dictionary<string, Point> result = new Dictionary<string, Point>();

            foreach (var automatGroup in _DAL.LoadAutomatChainConfiguration())
            {
                foreach (var element in automatGroup.GroupElements)
                {
                    result.Add(element.AutomatName, element.AutomatLocation);
                }
            }

            return result;
        }

        public List<ChainModellingGroupOfElements> LoadAutomatGroups() => _DAL.LoadAutomatChainConfiguration().ToList();

        public void SaveAutomatChainAppearance(Dictionary<string, Point> nameAndLocationPair)
        {
            _DAL.SaveAutomatChainConfiguration(DivideAutomatByGroups(nameAndLocationPair.OrderBy((pair) => pair.Value.X)
                .ToDictionary(pair => pair.Key, pair => pair.Value)));
        }


        public List<ChainModellingGroupOfElements> DivideAutomatByGroups(Dictionary<string, Point> dataToDivision)
        {
            List<ChainModellingGroupOfElements> result = new List<ChainModellingGroupOfElements>();

            while (dataToDivision.Count > 0)
            {
                List<ChainElemViewInfo> group = new List<ChainElemViewInfo>();

                var elemToCompare = dataToDivision.ElementAt(0);

                if (dataToDivision.Count == 1)
                {
                    group.Add(new ChainElemViewInfo(elemToCompare.Value, elemToCompare.Key));

                    result.Add(new ChainModellingGroupOfElements(result.Count + 1, group));

                    break;
                }

                foreach (var item in dataToDivision)
                {
                    if (item.Key == elemToCompare.Key)
                        continue;

                    if (Math.Abs(item.Value.X - elemToCompare.Value.X) <= 20)
                        group.Add(new ChainElemViewInfo(item.Value, item.Key));
                }

                group.Add(new ChainElemViewInfo(elemToCompare.Value, elemToCompare.Key));

                group.ForEach((KeyValuePair) => dataToDivision.Remove(KeyValuePair.AutomatName));

                result.Add(new ChainModellingGroupOfElements(result.Count + 1, group));
            }

            return result;
        }

        public bool IsChainModellingModeActive()
        => _DAL.IsChainModellingModeActive();

        public int GetAutomatGroup(string automatName)
        {
            foreach (var element in _DAL.LoadAutomatChainConfiguration())
            {
                if (element.GroupElements.Any((elemInfo) => elemInfo.AutomatName == automatName))
                    return element.GroupNumber;
            }

            return -1;
        }

        public string CalculateAutomatInputSignals(string automatName)
            => _DAL.CalculateGroupOutputSignal(
                GetGroupNames(
                    _DAL.GetElementGroups()
                    .ElementAt(GetAutomatGroup(automatName) - 2).GroupElements));

        List<string> GetGroupNames(IEnumerable<ChainElemViewInfo> groupElements)
        {
            List<string> result = new List<string>();

            foreach (var item in groupElements)
            {
                result.Add(item.AutomatName);
            }

            return result;
        }
    }
}
