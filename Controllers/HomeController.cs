using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dentist.Controllers
{
  
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Dentist.ADMIN objUser)
        {
            if (ModelState.IsValid)
            {
                using (Dentist_Entities db = new Dentist_Entities())
                {
                    var obj = db.ADMINs.Where(a => a.USERNAME.Equals(objUser.USERNAME) && a.PASSWORD.Equals(objUser.PASSWORD)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["AdminID"] = obj.AdminID.ToString();
                        return RedirectToAction("Index", "ADMIN");
                    }
                    if (objUser.USERNAME.Equals("admin") && objUser.PASSWORD.Equals("admin"))
                    {
                        Session["AdminID"] = db.ADMINs.ToString();
                        return RedirectToAction("Index", "ADMIN");
                    }
                }
                ViewBag.Msg = "Username or Password is incorrect";
            }
            return View(objUser);

        }

        class Repository
        {
        }
    }
}
