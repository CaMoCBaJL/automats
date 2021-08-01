using BLInterfaces;
using DalInterfaces;
using System.Collections.Generic;

namespace DataProvidingLogic
{
    public class BuisnessLogic : IDataProviderLogic
    {
        IDataProvider _DAL;

        public BuisnessLogic(IDataProvider dal) => _DAL = dal;


        public List<string> GetData(string path)
        => _DAL.GetData(path);
    }
}
