using bilel_net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bilel_net.Controllers
{
    public class LoginController : Controller
    {


        bilelEntities db = new bilelEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Index(user objct)
        {

            if(ModelState.IsValid)
            {
                using (bilelEntities db = new bilelEntities())
                {
                    var obj = db.users.Where(a => a.username.Equals(objct.username) && a.password.Equals(objct.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserId"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username ou Mot de passe est incorrect");
                    }

                }


            }

            
                
                    
                    return View(objct);
        }
        public ActionResult Logout ()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }


    }
}