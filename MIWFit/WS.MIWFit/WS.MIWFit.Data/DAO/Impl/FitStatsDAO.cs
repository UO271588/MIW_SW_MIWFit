using Microsoft.EntityFrameworkCore;
using WS.MIWFit.Data.Model;
using WS.Unit06.Example2.Data.DAO;

namespace WS.MIWFit.Data.DAO.Impl
{
    public class FitStatsDAO : GenericDAO<FitStats>, IFitStatsDAO
    {
        public FitStatsDAO(DataContext context) : base(context)
        {
        }

        public IEnumerable<FitStats> findByUsername(string username)
        {
            return DbSet.Where( fitStats => fitStats.User.Username == username).ToList();
        }
    }
}
