using Entities;
using System.Collections.Generic;

namespace BLInterfaces
{
    public interface IAutomatExperimentLogic
    {
        Dictionary<int, List<AGroup>> StartTheExperiment(List<int> initialConditionsSet,
            int[,] conditionTable, string[,] outputTable, ExperimentType experimentType);
    }
}
