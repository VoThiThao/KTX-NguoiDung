using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KTX.Models;
using Models.DAO;
using KTX.Common;
using Models.EF;


namespace KTX.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.login(user.TenDangNhap, user.MatKhau,0);
                var result1 = dao.login(user.TenDangNhap, user.MatKhau, 1);
                if (result1==1){
                  
                    //ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION,user);
                    return RedirectToAction("Index", "TC");
                }
                if (result == 1)
                {

                    //ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "QLSV");
                }
                
                else
                {
                    ModelState.AddModelError("", "Vui lòng kiểm tra lại tài khoản");
                }
            }
            return View("Index");
        }
    }
}