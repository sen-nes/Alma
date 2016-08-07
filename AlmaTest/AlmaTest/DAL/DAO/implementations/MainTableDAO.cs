using AlmaTest.DAL.DAO.interfaces;
using AlmaTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace AlmaTest.DAO
{
    public class MainTableDAO : BaseDAO<MainTable>
    {
        private AlmaContext db;

        public MainTableDAO()
        {
            db = new AlmaContext();
        }

        public IQueryable<MainTable> FindAll()
        {
            var result = db.MainTable.OrderBy(r => r.Client);

            return result;
        }
        
        public IQueryable<MainTable> FindByClient(string client)
        {
            var result = from rec in db.MainTable
                         select rec;
            result = result.Where(r => r.Client.Equals(client)).OrderBy(r => r.Client);

            return result;
        }

        public List<MainTable> GetPage(IQueryable<MainTable> clients, int page, int perPage)
        {
            int skip = page * perPage;
            var result = clients.Skip(skip).Take(perPage);

            return result.ToList();
        }

        public MainTable FindByID(int id)
        {
            var client = db.MainTable.Where(c => c.ID == id).FirstOrDefault();

            return client;
        }

        public string[] GetClientNames()
        {
            var names = from rec in db.MainTable
                        select rec.Client;
            names = names.Distinct();

            return names.ToArray();
        }
    }
}