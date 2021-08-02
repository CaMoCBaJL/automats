﻿using System;
using System.Collections.Generic;
using System.IO;
using DalInterfaces;
using Entities;
using Newtonsoft.Json;

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

        public IEnumerable<string> GetData(string pathToFile) => File.ReadAllText(pathToFile).Split(new char[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);

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

        public void SerializeAutomatChain(string data)
        {
            if (!File.Exists(PathConstants.chainModellingConfigurationFile))
                File.Create(PathConstants.chainModellingConfigurationFile);

            File.WriteAllText(PathConstants.chainModellingConfigurationFile, data);
        }
    }
}
