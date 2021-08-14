﻿using DataAccessLayer;
using DalInterfaces;
using BLInterfaces;
using BuisnessLogic;

namespace Dependencies
{
    public class DependencyResolver
    {
        #region Singleton
        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DependencyResolver();

                return _instance;
            }
        }
        #endregion


        ICryptoStrengthTestDataTransmitterDAL cryptoStrengthTestDAL = new CryptoStrengthTestDAL();

        IDataProvider DAL => new DataIntegrityDAL();

        IAutomatChainModellingDAL ModellingDAL => new AutomatChainModellingDAL();

        public IDataProviderLogic BL => new DataProvidingLogic(DAL);

        public IAutomatChainModellingLogic ChainModellingBL => new AutomatChainModellingLogic(ModellingDAL);

        public IAutomatModellingLogic AutomatModellingBL => new ModellingLogic();

        public IAutomatExperimentLogic AutomatExperimentLogic => new ExperimentLogic();

        public ICryptoStrengthTestLogic BinaryCryptoStrengthTest => new BinaryCryptoStrengthTestLogic(cryptoStrengthTestDAL);
    }
}
