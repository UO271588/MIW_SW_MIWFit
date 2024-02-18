using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS.MIWFit.Data;
using WS.MIWFit.Data.DAO;
using WS.MIWFit.Data.DAO.Impl;

namespace WS.MIWFit.Data
{
    public class DAOFactory : IDisposable
    {
        private DataContext _context;

        public DAOFactory()
        {
            _context = new DataContext();
        }

        public IUserDAO UserDAO
        {
            get { return new UserDAO(_context); }
        }

        public IFitStatsDAO FitStatsDAO
        {
            get { return new FitStatsDAO(_context); }
        }


        public void Dispose() { _context.Dispose(); }
    }
}