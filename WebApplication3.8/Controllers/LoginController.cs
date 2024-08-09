using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3._8.Models;

namespace WebApplication3._8.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.Taikhoans.Where(u => u.tendn == username && u.matkhau == password).FirstOrDefault();
            if (user == null)
            {
                ViewBag.errLogin = "Sai tên đăng nhập hoặc mật khẩu";
                return View("Login");
            }
            else
            {
                Session["username"] = username;
                return RedirectToAction("Index", "NhanViens"); //chạy tới action Index
            }
        }
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}