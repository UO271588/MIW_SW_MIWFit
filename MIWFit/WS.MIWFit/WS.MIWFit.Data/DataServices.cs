using System.ServiceModel;
using WS.MIWFit.Data.Model;
using WS.MIWFit.Data;

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

        public void CreateUserFitStats(FitStats fitStats)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                var user = factory.UserDAO.All().FirstOrDefault(u => u.Username == fitStats.User.Username);

                if (user == null)
                {
                    throw new FaultException(new FaultReason("User " + fitStats.User.Username + " not found"), new FaultCode("404"), "");
                }

                
                fitStats.Date = DateTime.Now;
                user.FitStats.Add(fitStats);

                var result = factory.UserDAO.Update(user);
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
                FitStats[] fitStats = factory.FitStatsDAO.findByUsername(username).ToArray();

                return fitStats;
            }
        }
    }
}
