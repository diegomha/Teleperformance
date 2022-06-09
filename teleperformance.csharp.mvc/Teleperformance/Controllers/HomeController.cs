using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teleperformance.Helpers;

namespace Teleperformance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //UserRepository user = new UserRepository();
            //Users us = new Users() { Name = "teleperformance", Password = SecurityHelper.MD5("qwerty987654*", true), PhoneNumber = "+5511947303699" };
            //user.Insert(ref us);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoLogging(FormCollection formCollection)
        {
            var userRequest = Convert.ToString(formCollection["txtUser"]).Trim();
            var passwordRequest = Convert.ToString(formCollection["txtPassword"]).Trim();

            UserRepository userRepository = new UserRepository();
            passwordRequest = SecurityHelper.MD5(passwordRequest, true);
            Users user = userRepository.GetList(w => w.Name == userRequest && w.Password == passwordRequest).FirstOrDefault();

            if (user != null)
            {
                TempData["Msg"] = "";
                Session.Add("UserLogged", user);
                return RedirectToAction("UserAdmin", "AdminArea");
            }
            else
            {
                TempData["Msg"] = "Usuário ou senha inválidos";
                Session.Remove("UserLogged");
                return RedirectToAction("/");
            }
        }
    }
}