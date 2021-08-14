using BLInterfaces;
using DalInterfaces;
using System.Collections.Generic;
using Entities;
using System.Text;
using System;

namespace BuisnessLogic
{
    public class DataProvidingLogic : IDataProviderLogic
    {
        IDataProvider _DAL;

        public DataProvidingLogic(IDataProvider dal) => _DAL = dal;

        public bool AddAutomatData(string automatTablesFileName, string inputSignalsString, string outputSignalsString, string automatName,
            string startConditions)
               => _DAL.SaveAutomatWorkData(new ChainElementSettings(automatTablesFileName, inputSignalsString, outputSignalsString, automatName, startConditions));

        public List<string> GetData(string path)
               => new List<string>(_DAL.GetData(path));

        public ChainElementSettings LoadAutomatSettings(string automatName)
           => _DAL.LoadAutomatSettings(automatName);
        
        public Automat ParseAutomatDataTables(string pathToFile)
        {
            var automat = new Automat();

            var data = _DAL.ParseAutomatData(pathToFile);

            automat.SetDeltaTable(data.DeltaTable);

            automat.SetLambdaTable(data.LambdaTable);

            return automat;
        }

        public string ReadAllBytesFromFile(string fileName)
        {
            StringBuilder result = new StringBuilder();

            foreach(var dataPiece in _DAL.ReadAllBytes(fileName))
            {
                result.Append(Convert.ToString(dataPiece, 2));
            }

            return result.ToString();
        }
    }
}
