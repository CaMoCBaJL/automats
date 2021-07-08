using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class DAL
    {
        public List<string> GetData(string pathToFile) => File.ReadAllText(pathToFile).Split(new char[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

    }
}
