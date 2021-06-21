using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automats
{
    public class AutOptions
    {
        public static int AutNum { get; private set; }


        public Label Label { get; }

        public string DataFile { get; set; }

        public StringBuilder InputSignals { get; set; }

        public StringBuilder StartCondition { get; set; }

        public StringBuilder OutputSignals { get; set; }

        static AutOptions() => AutNum = 0;

        public AutOptions(Label label, string filename, StringBuilder X, StringBuilder name, StringBuilder Y)
        {
            Label = label;
            DataFile = filename;
            InputSignals = X;
            StartCondition = name;
            OutputSignals = Y;
            AutNum++;
        }

        public static void ResetAutCounter() => AutNum = 1;

    }
}
