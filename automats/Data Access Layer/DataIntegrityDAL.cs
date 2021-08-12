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

        public ChainElementSettings LoadAutomatSettings(string automatName)
            => JsonConvert.DeserializeObject<ChainElementSettings>(
                File.ReadAllText(
                    PathConstants.automatChainModellingFolder + Path.DirectorySeparatorChar + automatName + ".json"));
        

        public (int[,] DeltaTable, string[,] LambdaTable) ParseAutomatData(string pathToFile)
            => new AutomatParser(pathToFile).ParseData();

        public byte[] ReadAllBytes(string fileName)
        => File.ReadAllBytes(fileName);

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
