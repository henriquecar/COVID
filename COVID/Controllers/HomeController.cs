using COVID.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace COVID.Controllers
{
    public class HomeController : Controller
    {
        [OutputCacheAttribute(Duration = 3600)]
        public async Task<ActionResult> Index()
        {
            var business = new CovidBusiness();
            try
            {
                var result = await business.ListTop10();
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Erro");
            }
        }

        public ActionResult Erro()
        {
            return View();
        }
    }
}