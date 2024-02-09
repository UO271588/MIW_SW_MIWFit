using System.ServiceModel;
using WS.MIWFit.Data.Model;

namespace WS.MIWFit.Data
{
    public interface IDataServices
    {

        //OPERACIONES USERS
        [OperationContract]
        public User GetUser(String username);
        [OperationContract]
        public void CreateUser(String username);


        //OPERACIONES FIT STATS
        [OperationContract]
        public FitStats[] GetUserFitStats(String username);
        [OperationContract]
        public void CreateUserFitStats(String username);
    }
}
