using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatFunctions
{
    public static class Operations
    {
        static public int Delta(int[,] condTable, int sj, int xj) => condTable[sj - 1, xj];

        static public string Lambda(string[,] outputTable, int sj, int xj) => outputTable[sj - 1, xj];

    }
}
