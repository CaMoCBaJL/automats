using System.Collections.Generic;

namespace BLInterfaces
{
    public interface IDataProviderLogic
    {
        List<string> GetData(string path);
    }
}
