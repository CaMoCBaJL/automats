using Entities;
using System.Collections.Generic;

namespace DalInterfaces
{
    public interface ICryptoStrengthTestDataTransmitterDAL
    {
        bool SaveExecutionData(ModellingStepData firstStep, ModellingStepData lastStep);

        void EndCryptoStrengthTest();

        Dictionary<ModellingStepData, ModellingStepData> LoadExecutionData();

        void CheckDataFolderIntegrity();

        KeyValuePair<ModellingStepData,  ModellingStepData> LoadNewCycleData(string pathToFile);
    }
}
