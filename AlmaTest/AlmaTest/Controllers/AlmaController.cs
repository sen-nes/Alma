using AlmaTest.DAO;
using AlmaTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AlmaTest.Controllers
{
    public class AlmaController : Controller
    {
        public ActionResult Modules()
        {
            ModuleDAO dao = new ModuleDAO();
            var modules = dao.FindAll();
            var vm = new ModulesViewModel
            {
                Modules = modules.ToList<Modules>()
        };

            return View(vm);
        }
        
        public ActionResult MainTable(MainTableViewModel vmPass, int? page, string client)
        {
            MainTableDAO dao = new MainTableDAO();
            List<MainTable> clients = new List<MainTable>();
            ViewBag.vm = vmPass.Clients;
            if (page == null || page < 1)
            {
                page = 1;
            }

            if (client != null)
            {
                clients = dao.GetPage(dao.FindByClient(client), (int)page - 1, 25);
            } else
            {
                clients = dao.GetPage(dao.FindAll(), (int)page - 1, 25);
            }
            

            var vm = new MainTableViewModel
            {
                Clients = clients,
                Client = client,
                Page = (int)page,
                RecordsPerPage = 25
            };

            return View(vm);
        }
    }
}