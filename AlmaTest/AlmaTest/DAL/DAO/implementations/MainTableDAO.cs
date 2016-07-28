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
            // Fix number to take
            var result = db.MainTable.Take(25).ToList<MainTable>();

            return result;
        }

        public List<MainTable> FindByDistributor(string distributor)
        {
            var result = from rec in db.MainTable
                         select rec;
            result = result.Where(r => r.Distributor.Equals(distributor));

            return result.ToList<MainTable>();
        }
    }
}