using System.Collections.Generic;

namespace BLInterfaces
{
    public interface IDataProviderLogic
    {
        List<string> GetData(string path);

        void SaveAutomatChainAppearance(Dictionary<int, string> elementsLocation);

        Dictionary<int, string> LoadAutomatChainAppearance();
    }
}
