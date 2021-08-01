using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DalInterfaces;

namespace DataAccessLayer
{
    public class DAL : IDataProvider
    {
        public List<string> GetData(string pathToFile) => File.ReadAllText(pathToFile).Split(new char[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

    }
}
