using System.Collections.Generic;
using System.IO;
using DalInterfaces;
using System.Text;
using Entities;
using CommonConstants;
using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class AutomatChainModellingDAL : IAutomatChainModellingDAL
    {
        public void StartAutomatChainModelling()
        {
            Directory.CreateDirectory(PathConstants.automatChainModellingFolder);

            new FileStream(PathConstants.chainModellingConfigurationFile, FileMode.CreateNew).Close();
        }

        public void EndAutomatChainModelling()
        {
            if (Directory.Exists(PathConstants.automatChainModellingFolder))
                Directory.Delete(PathConstants.automatChainModellingFolder, true);
        }

        public void SaveAutomatChainConfiguration(IEnumerable<ChainModellingGroupOfElements> chainConfiguration)
        {
            File.WriteAllText(PathConstants.chainModellingConfigurationFile, JsonConvert.SerializeObject(chainConfiguration));
        }

        public IEnumerable<ChainModellingGroupOfElements> LoadAutomatChainConfiguration()
        {
            if (File.Exists(PathConstants.chainModellingConfigurationFile))
                if (!string.IsNullOrEmpty(File.ReadAllText(PathConstants.chainModellingConfigurationFile)))
                    return JsonConvert.DeserializeObject<List<ChainModellingGroupOfElements>>(
                        File.ReadAllText(PathConstants.chainModellingConfigurationFile));

            return new ChainModellingGroupOfElements[] { };
        }

        public bool DidAutomatWork(string fileName)
        => File.Exists(fileName);


        public bool DidGroupElementsWork(IEnumerable<string> groupElems)
        {
            foreach (string fileName in groupElems)
            {
                if (!File.Exists(PathConstants.automatChainModellingFolder + "/" + fileName +".json"))
                    return false;
            }

            return true;
        }

        public string CalculateGroupOutputSignal(IEnumerable<string> groupElems)
        {
            if (!DidGroupElementsWork(groupElems))
                return string.Empty;

            StringBuilder result = new StringBuilder();

            foreach (string fileName in groupElems)
                result.Append(GetChainElement(PathConstants.automatChainModellingFolder + "/" + fileName + ".json").OutputSignalString);

            return result.ToString();
        }

        public bool IsChainModellingModeActive()
        => Directory.Exists(PathConstants.automatChainModellingFolder);

        public ChainElementSettings GetChainElement(string pathToFile)
        => JsonConvert.DeserializeObject<ChainElementSettings>(File.ReadAllText(pathToFile));

        public IEnumerable<ChainModellingGroupOfElements> GetElementGroups()
        => JsonConvert.DeserializeObject<List<ChainModellingGroupOfElements>>(File.ReadAllText(PathConstants.chainModellingConfigurationFile));
    }
}
