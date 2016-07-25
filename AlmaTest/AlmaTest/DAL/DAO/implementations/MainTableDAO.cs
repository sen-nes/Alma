using AlmaTest.DAL.DAO.interfaces;
using AlmaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmaTest.DAO
{
    public class MainTableDAO : BaseDAO<MainTable>
    {
        private AlmaContext db;

        public MainTableDAO()
        {
            db = new AlmaContext();
        }

        public List<MainTable> FindAll()
        {
            var result = db.MainTable.ToList<MainTable>();

            return result;
        }
    }
}