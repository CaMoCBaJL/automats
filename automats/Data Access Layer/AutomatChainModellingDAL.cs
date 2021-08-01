using System.IO;
using DalInterfaces;

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
    }
}
