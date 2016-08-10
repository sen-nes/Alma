using AlmaTest.DAO;
using System.Web.Mvc;
using System.Web.Services;

namespace AlmaTest.Controllers
{
    public class apiController : Controller
    {
        [WebMethod]
        public JsonResult Clients(int? id)
        {
            MainTableDAO dao = new MainTableDAO();
            object result;
            if (id == null)
            {
                result = dao.GetClientNames();
            } else
            {
                result = dao.FindByID((int)id);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [WebMethod]
        public JsonResult Modules()
        {
            ModuleDAO dao = new ModuleDAO();
            var modules = dao.GetModules();

            return Json(modules, JsonRequestBehavior.AllowGet);
        }
    }
}