using System.ServiceModel;
using WS.MIWFit.Data.Model;
using WS.Unit06.Example2.Data;

namespace WS.MIWFit.Data
{
    public class DataServices : IDataServices
    {
        public void CreateUser(String username, String password, String genre, String mail)
        {
            using (DAOFactory factory = new DAOFactory()){
                var user = factory.UserDAO.All().FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    throw new FaultException(new FaultReason("User already exists!!!"), new FaultCode("400"), "");
                }

                factory.UserDAO.Add(new User() { Username = username, Password = password, Genre = genre, Mail = mail });
            }
        }

        public void CreateUserFitStats(String username)
        {
            using (DAOFactory factory = new DAOFactory())
            {

            }
        }

        public User GetUser(String username)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                var user = factory.UserDAO.All().FirstOrDefault(u => u.Username == username);

                return user != null ? user : new User();
            }
        }

        public FitStats[] GetUserFitStats(String username)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.FitStatsDAO.All().Where(s => s.User.Username == username).ToArray();
            }
        }
    }
}
