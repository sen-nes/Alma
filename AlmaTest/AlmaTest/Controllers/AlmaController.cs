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

        [HttpGet]
        public ActionResult MainTable()
        {
            MainTableDAO dao = new MainTableDAO();
            var vm = new MainTableViewModel
            {
                Distributor = null,
                Clients = dao.FindAll()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult MainTable(string distributor)
        {
            MainTableDAO dao = new MainTableDAO();
            var vm = new MainTableViewModel
            {
                Distributor = distributor,
                Clients = dao.FindByDistributor(distributor)
            };

            return View(vm);
        }
    }
}