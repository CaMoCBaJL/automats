﻿using BLInterfaces;
using DalInterfaces;
using System.Collections.Generic;
using System.Drawing;
using Entities;
using CommonLogic;
namespace BuisnessLogic
{
    public class DataProvidingLogic : IDataProviderLogic
    {
        IDataProvider _DAL;

        public DataProvidingLogic(IDataProvider dal) => _DAL = dal;

        public bool AddAutomatData(string automatTablesFileName, string inputSignalsString, string outputSignalsString, string automatName)
               => _DAL.SaveAutomatWorkData(new ChainElementSettings(automatTablesFileName, inputSignalsString, outputSignalsString, automatName));

        public List<string> GetData(string path)
               => new List<string>(_DAL.GetData(path));

        public Automat ParseAutomatDataTables(string pathToFile)
        {
            var automat = new Automat();

            var data = _DAL.ParseAutomatData(pathToFile);

            automat.SetDeltaTable(data.DeltaTable);

            automat.SetLambdaTable(data.LambdaTable);

            return automat;
        }

        
    }
}
