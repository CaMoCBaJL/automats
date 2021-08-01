using System.Linq;
using System.Collections.Generic;
using Entities;
using BLInterfaces;

namespace BuisnessLogic
{
    public class ExperimentLogic : IAutomatExperimentLogic
    {
        public Dictionary<int, List<AGroup>> StartTheExperiment(List<int> initialConditionsSet,
            int[,] conditionTable, string[,] outputTable, ExperimentType experimentType)
        {
            Dictionary<int, List<AGroup>> result = new Dictionary<int, List<AGroup>>();

            var initAGroup = new List<AGroup>();

            while (true)
            {
                if (result.Count == 0)
                {
                    initAGroup.Add(
                        new AGroup(
                        new SigmaSet[]{
                        new SigmaSet(initialConditionsSet, "-")
                                      }, null));

                    result.Add(0, initAGroup);
                }
                else
                    initAGroup = TrimTheTree(initAGroup, result[result.Count - 1], experimentType);

                if (initAGroup != null)
                    result.Add(result.Count, IterateTheExperiment(initAGroup, conditionTable, outputTable));
                else
                    throw new System.Exception("Ошибка!");

                switch (experimentType)
                {
                    case ExperimentType.Diagnostic:
                        if (result[result.Count - 1].Any((group) => group.AGroupType == AGroupAndSigmaSetType.Prime))
                            return result;
                        break;

                    case ExperimentType.Setting:
                        if (result[result.Count - 1].Any((group) => AGroup.IsGroupHomogenous(group)))
                            return result;
                        break;

                    case ExperimentType.None:
                    default:
                        break;
                }
            }
        }

        List<AGroup> TrimTheTree(List<AGroup> penultimateLayer,List<AGroup> lastLayer, ExperimentType experimentType)
        {
            switch (experimentType)
            {
                case ExperimentType.Diagnostic:
                    return lastLayer.FindAll((group) =>
                    (!group.AGroupContent.Any((sigmaSet) => sigmaSet.SetType == AGroupAndSigmaSetType.Homogenous) 
                    && !group.AGroupContent.Any((sigmaSet) => sigmaSet.SetType == AGroupAndSigmaSetType.Multiple))
                    && !penultimateLayer.Contains(group));

                case ExperimentType.Setting:
                    return lastLayer.FindAll((group) =>
                    !penultimateLayer.Contains(group));

                case ExperimentType.None:
                default:
                    return null;
            }

        }

        AGroup UpdateSigmaSets(AGroup group)
        {
            AGroup newAgroup = new AGroup(group.AncestorAGroup);

            foreach (var sigmaSet in group.AGroupContent)
            {
                foreach (var setItems in sigmaSet.SetContent)
                    newAgroup.AddElement(new SigmaSet(setItems));
            }

            return newAgroup;
        }

        List<AGroup> IterateTheExperiment(List<AGroup> groups,
            int[,] conditionTable, string[,] outputTable)
        {
            List<AGroup> iterataionResult = new List<AGroup>();

            var inputSignals = new SortedSet<string>(outputTable.Cast<string>());

            foreach (var aGroup in groups)
            {
                for (int inputSignal = 0; inputSignal < inputSignals.Count; inputSignal++)
                {
                    AGroup newGroup = new AGroup(aGroup);

                    foreach (var sigmaSet in aGroup.AGroupContent)
                    {
                        foreach (var conditionSet in sigmaSet.SetContent.Values)
                        {
                            SigmaSet newSet = new SigmaSet();

                            foreach (var condition in conditionSet)
                                newSet.Add(Automat.AutomatFunction(outputTable, condition - 1, inputSignal),
                                    Automat.AutomatFunction(conditionTable, condition - 1, inputSignal));

                            newGroup.AddElement(newSet);
                        }
                    }

                    iterataionResult.Add(UpdateSigmaSets(newGroup));
                }
            }

            return iterataionResult;
        }
    }
}
