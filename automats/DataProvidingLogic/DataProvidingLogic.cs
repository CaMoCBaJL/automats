using BLInterfaces;
using DalInterfaces;
using System.Collections.Generic;

namespace DataProvidingLogic
{
    public class DataProvidingLogic : IDataProviderLogic
    {
        IDataProvider _DAL;

        public DataProvidingLogic(IDataProvider dal) => _DAL = dal;


        public List<string> GetData(string path)
        => _DAL.GetData(path);
    }
}
