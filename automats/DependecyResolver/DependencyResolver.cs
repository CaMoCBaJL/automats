using DataAccessLayer;
using DataProvidingLogic;
using DalInterfaces;
using BLInterfaces;

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

        IDataProvider DAL => new DAL();

        IAutomatChainModellingDAL ModellingDAL => new AutomatChainModellingDAL();

        public IDataProviderLogic BL => new BuisnessLogic(DAL);

        public IChainModellingLogic ChainModellingBL => new AutomatChainModellingLogic(ModellingDAL);
    }
}
