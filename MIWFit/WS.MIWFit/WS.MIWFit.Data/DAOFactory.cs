using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS.Unit06.Example2.Data.DAO;
using WS.Unit06.Example2.Data.DAO.Impl;

namespace WS.Unit06.Example2.Data
{
    public class DAOFactory : IDisposable
    {
        private DataContext _context;

        public DAOFactory()
        {
            _context = new DataContext();
        }

        public IStatisticsDAO StatisticsDAO
        {
            get { return new StatisticsDAO(_context); }
        }

        
        public void Dispose() { _context.Dispose(); }
    }
}