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

        public bool DidAutomatWork(string fileName)
        => File.Exists(fileName);
        

        public bool DidGroupElementsWork(IEnumerable<string> groupElems)
        {
            foreach(string fileName in groupElems)
            {
                if (!File.Exists(fileName))
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
                result.Append(GetChainElement(fileName).OutputSignalString);

            return result.ToString();
        }

        public bool IsChainModellingModeActive()
        => Directory.Exists(PathConstants.automatChainModellingFolder);

        public ChainElementSettings GetChainElement(string pathToFile)
        => JsonConvert.DeserializeObject<ChainElementSettings>(File.ReadAllText(pathToFile));
        
    }
}
