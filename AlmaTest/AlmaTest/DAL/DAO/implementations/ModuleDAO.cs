using AlmaTest.DAL.DAO.interfaces;
using AlmaTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace AlmaTest.DAO
{
    public class ModuleDAO : BaseDAO<Modules>
    {
        private AlmaContext db;

        public ModuleDAO()
        {
            db = new AlmaContext();
        }

        public List<Modules> FindAll()
        {
            var modules = db.Modules.ToList<Modules>();

            return modules;
        }
    }
}