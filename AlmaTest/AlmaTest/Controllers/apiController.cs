using AlmaTest.DAO;
using System.Web.Mvc;
using System.Web.Services;

namespace AlmaTest.Controllers
{
    public class apiController : Controller
    {
        [WebMethod]
        public JsonResult ClientNames()
        {
            MainTableDAO dao = new MainTableDAO();
            var clientNames = dao.GetClientNames();

            return Json(clientNames, JsonRequestBehavior.AllowGet);
        }

        [WebMethod]
        public JsonResult Client(int id)
        {
            MainTableDAO dao = new MainTableDAO();
            var client = dao.FindByID(id);

            return Json(client, JsonRequestBehavior.AllowGet);
        }
    }
}