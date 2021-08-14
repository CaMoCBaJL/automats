using Entities;
using DalInterfaces;
using Newtonsoft.Json;
using System.IO;
using CommonConstants;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class CryptoStrengthTestDAL : ICryptoStrengthTestDataTransmitterDAL
    {
        public CryptoStrengthTestDAL()
        => CheckDataFolderIntegrity();

        public bool SaveExecutionData(ModellingStepData firstStep, ModellingStepData lastStep)
        {
            string fileName = (Directory.GetFiles(PathConstants.stengthTestDataFolder).Length + 1) + ".json";

            try
            {
                File.WriteAllText(PathConstants.stengthTestDataFolder + Path.DirectorySeparatorChar + fileName,
                    JsonConvert.SerializeObject(new ModellingStepData[] { firstStep, lastStep }));

                return true;
            }
            catch
            {
                return false;
            }
        }

        void CheckDataFolderIntegrity()
        {
            if (!Directory.Exists(PathConstants.stengthTestDataFolder))
                Directory.CreateDirectory(PathConstants.stengthTestDataFolder);
        }

        public void EndCryptoStrengthTest()
        {
            if (!Directory.Exists(PathConstants.stengthTestDataFolder))
                Directory.Delete(PathConstants.stengthTestDataFolder);
        }

        public Dictionary<ModellingStepData, ModellingStepData> LoadExecutionData()
        {
            Dictionary<ModellingStepData, ModellingStepData> dataToShow = new Dictionary<ModellingStepData, ModellingStepData>();

            foreach (var fileName in Directory.GetFiles(PathConstants.stengthTestDataFolder))
            {
                var cycleSteps = JsonConvert.DeserializeObject<KeyValuePair<ModellingStepData, ModellingStepData>>(File.ReadAllText(fileName));

                dataToShow.Add(cycleSteps.Key, cycleSteps.Value);
            }

            return dataToShow;
        }
    }
}
