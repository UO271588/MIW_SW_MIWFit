using WS.MIWFit.Data.Model;
using WS.Unit06.Example2.Data.DAO;

namespace WS.MIWFit.Data.DAO.Impl
{
    public class UserDAO : GenericDAO<User>, IUserDAO
    {
        public UserDAO(DataContext context) : base(context)
        {
        }
    }
}
