using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaTest.DAL.DAO.interfaces
{
    interface BaseDAO<T>
    {
        IQueryable<T> FindAll();
    }
}
