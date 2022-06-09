using Core.Entities;
using Core.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teleperformance.Helpers;

namespace Teleperformance.Areas.AdminArea.Controllers
{
    public class UserAdminController : Controller
    {
        UserRepository _userRepository = new UserRepository();

        public UserAdminController()
        {
            if (System.Web.HttpContext.Current.Session["UserLogged"] == null)
            {
                TempData["Msg"] = "Usuário ou senha inválidos";
                Response.Redirect("/");
            }
        }

        // GET: AdminArea/UserAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminArea/GetUsers
        public JsonResult GetUsers()
        {
            List<Users> lstUsers = _userRepository.GetAll().ToList();

            Dictionary<string, object> dicResult = new Dictionary<string, object>();
            dicResult.Add("draw", lstUsers.Count());
            dicResult.Add("recordsTotal", lstUsers.Count());
            dicResult.Add("recordsFiltered", lstUsers.Count());
            dicResult.Add("data", lstUsers.ToArray());

            return Json(dicResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserById(int Id)
        {
            Users user = _userRepository.GetById(Id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(string userName, string userPassword, string userPhone)
        {
            Users usr = new Users()
            {
                Name = userName.Trim(),
                Password = SecurityHelper.MD5(userPassword.Trim(), true),
                PhoneNumber = userPhone.Trim()
            };

            try 
            {   
                _userRepository.Insert(ref usr);
            }
            catch { }

            return Json(usr, JsonRequestBehavior.AllowGet);
        }

        public string Update(int Id, string userName, string userPassword, string userPhone)
        {
            Users usr = _userRepository.GetById(Id);
            usr.Name = userName.Trim();
            usr.Password = SecurityHelper.MD5(userPassword.Trim(), true);
            usr.PhoneNumber = userPhone.Trim();

            string result = "False";
            try { 
                result = _userRepository.Update(usr).ToString();
            }
            catch { }

            return result;
        }

        public bool Delete(int Id)
        {
            return _userRepository.Delete(Id);
        }
    }
}