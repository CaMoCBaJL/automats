using DataAccessLayer;
using DalInterfaces;
using BLInterfaces;
using BuisnessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace Dependencies
{
    public class DependencyResolver
    {
        #region Singleton
        private static DependencyResolver _instance;

        private DependencyResolver()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton(typeof(IAutomatChainModellingLogic), new AutomatChainModellingLogic(modellingDAL));

            services.AddSingleton(typeof(IDataProviderLogic), new DataProvidingLogic(dataIntegrityDAL));

            services.AddSingleton(typeof(IAutomatExperimentLogic), new ExperimentLogic());

            services.AddSingleton(typeof(IAutomatModellingLogic), new ModellingLogic());

            services.AddSingleton(typeof(ICryptoStrengthTestLogic), new BinaryCryptoStrengthTestLogic(cryptoStrengthTestDAL));

            ServiceProvider = services.BuildServiceProvider();
        }

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

        IDataProvider dataIntegrityDAL => new DataIntegrityDAL();

        IAutomatChainModellingDAL modellingDAL => new AutomatChainModellingDAL();

        public ServiceProvider ServiceProvider;
    }
}
