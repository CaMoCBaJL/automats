namespace Entities
{
    public class Automat
    {
        public int[,] DeltaTable { get; private set; }

        public string[,] LambdaTable { get; private set; }


        public Automat(){}

        public void SetDeltaTable(int[,] conditionsTable) => DeltaTable = conditionsTable;

        public void SetLambdaTable(string[,] outptTable) => LambdaTable = outptTable;


        public static T AutomatFunction<T>(T[,] dataTable, int condition, int signalNum) => dataTable[condition, signalNum];
    }
}
