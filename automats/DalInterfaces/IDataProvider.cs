using System.Collections.Generic;

namespace DalInterfaces
{
    public interface IDataProvider
    {
        List<string> GetData(string pathToFile);
    }
}
