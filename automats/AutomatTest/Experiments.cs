using System.Linq;
using System.Collections.Generic;
using automats;

namespace AutomatTest
{
    static class Experiments
    {
        public enum ExperimentType
        {
            None,
            Diagnostic,
            Setting//установочный
        }


        static public List<List<AGroup>> StartTheExperiment(List<int> initialConditionsSet,
            int[,] conditionTable, string[,] outputTable, ExperimentType experimentType)
        {
            List<List<AGroup>> result = new List<List<AGroup>>();

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
                }
                else
                    initAGroup = TrimTheTree(initAGroup, result[result.Count - 1], experimentType);

                if (initAGroup != null)
                    result.Add(IterateTheExperiment(initAGroup, conditionTable, outputTable));
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

        static List<AGroup> TrimTheTree(List<AGroup> penultimateLayer,List<AGroup> lastLayer, ExperimentType experimentType)
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

        static AGroup UpdateSigmaSets(AGroup group)
        {
            AGroup newAgroup = new AGroup(group.AncestorAGroup);

            foreach (var sigmaSet in group.AGroupContent)
            {
                foreach (var setItems in sigmaSet.SetContent)
                    newAgroup.AddElement(new SigmaSet(setItems));
            }

            return newAgroup;
        }

        static List<AGroup>  IterateTheExperiment(List<AGroup> groups,
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
                                newSet.Add(AutOptions.Lambda(outputTable, condition, inputSignal),
                                    AutOptions.Delta(conditionTable, condition, inputSignal));

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
