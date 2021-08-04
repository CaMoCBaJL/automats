using System.IO;

namespace CommonConstants
{
    public static class PathConstants
    {
        public const string automatChainModellingFolder = "./ChainModelling";

        public static string chainModellingConfigurationFile = automatChainModellingFolder + Path.DirectorySeparatorChar + "Config.json";
    }
}
