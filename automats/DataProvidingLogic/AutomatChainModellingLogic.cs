using BLInterfaces;
using DalInterfaces;

namespace DataProvidingLogic
{
    public class AutomatChainModellingLogic : IChainModellingLogic;
    {
        IAutomatChainModellingDAL _DAL;

        public AutomatChainModellingLogic(IAutomatChainModellingDAL dal) => _DAL = dal;


        public void StartAutomatChainModelling()
        => _DAL.StartAutomatChainModelling();

        public void EndAutomatChainModelling()
        => _DAL.EndAutomatChainModelling();
    }
}
