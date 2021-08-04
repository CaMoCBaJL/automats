using System;
using System.Collections.Generic;
using System.IO;
using DalInterfaces;
using Entities;
using Newtonsoft.Json;
using CommonConstants;

namespace DataAccessLayer
{
    public class DataIntegrityDAL : IDataProvider
    {
        public IEnumerable<string> GetData(string pathToFile) => File.ReadAllText(pathToFile).Split(new char[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);

        public IEnumerable<ChainModellingGroupOfElements> LoadAutomatChainConfiguration()
        {
            if (File.Exists(PathConstants.chainModellingConfigurationFile))
                return JsonConvert.DeserializeObject<List<ChainModellingGroupOfElements>>(PathConstants.chainModellingConfigurationFile);
            else
                return new ChainModellingGroupOfElements[] { };
        }

        public void SaveAutomatChainConfiguration(IEnumerable<ChainModellingGroupOfElements> chainConfiguration)
        {
            File.WriteAllText(JsonConvert.SerializeObject(chainConfiguration), PathConstants.chainModellingConfigurationFile);
        }

        public bool SaveAutomatWorkData(ChainElementSettings automatData)
        {
            try
            {
                File.WriteAllText(PathConstants.automatChainModellingFolder + Path.DirectorySeparatorChar + automatData.AutomatName + ".json",
                     JsonConvert.SerializeObject(automatData));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
