using System.Runtime.CompilerServices;
using System.ServiceModel;
using WS.MIWFit.Data.Model;

namespace WS.MIWFit.Data
{
    [ServiceContract(Namespace = "http://ws.miwfit/data/")]
    public interface IDataServices
    {

        //OPERACIONES USERS
        [OperationContract]
        public User GetUser(String username);
        [OperationContract]
        public void CreateUser(String username, String password, String genre, String mail);


        //OPERACIONES FIT STATS
        [OperationContract]
        public FitStats[] GetUserFitStats(String username);
        [OperationContract]
        public void CreateUserFitStats(FitStats fitStats);
    }
}
