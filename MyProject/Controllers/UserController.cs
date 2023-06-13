using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Welcome()
        {
            if (Session["uid"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}