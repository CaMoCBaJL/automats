using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DalInterfaces;

namespace DataAccessLayer
{
    public class DAL : IDataProvider
    {
        public IEnumerable<string> DeserializeAutomatChain()
        {
            if (File.Exists(PathConstants.chainModellingConfigurationFile))
                return File.ReadAllText(PathConstants.chainModellingConfigurationFile).Split(new char[] { '\n', '\r' });
            else
                return new string[] { };
        }

        public List<string> GetData(string pathToFile) => File.ReadAllText(pathToFile).Split(new char[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

        public void SerializeAutomatChain(string data)
        {
            if (!File.Exists(PathConstants.chainModellingConfigurationFile))
                File.Create(PathConstants.chainModellingConfigurationFile);

            File.WriteAllText(PathConstants.chainModellingConfigurationFile, data);
        }
    }
}
