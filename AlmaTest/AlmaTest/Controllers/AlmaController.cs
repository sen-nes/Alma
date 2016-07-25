using AlmaTest.DAO;
using AlmaTest.Models;
using System.Web.Mvc;

namespace AlmaTest.Controllers
{
    public class AlmaController : Controller
    {
        public ActionResult Modules()
        {
            ModuleDAO dao = new ModuleDAO();
            var vm = new ModulesViewModel
            {
                Modules = dao.FindAll()
            };

            return View(vm);
        }

        public ActionResult MainTable()
        {
            MainTableDAO dao = new MainTableDAO();
            var vm = new MainTableViewModel
            {
                Clients = dao.FindAll()
            };

            return View(vm);
        }
    }
}