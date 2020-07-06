using KTX.Models;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KTX.Controllers
{
    public class UserController :BaseController
    {
        // GET: Admin/User
       /* public ActionResult Index()
        {
            var user = new UserDAO();
            var model= user.ListAll();
            return View(model);
        }
        */
        public ActionResult Index(string searchString)
        {
            var user = new UserDAO();
            var model = user.ListWhereAll(searchString);
            @ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string tenDangNhap)
        {
            var user = new UserDAO().getByTenDangNhap(tenDangNhap);
            return View(user);
        }
      

        [HttpPost]
        
        public ActionResult Create(NGUOIDUNG ngDung)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.Find(ngDung.TenDangNhap) != null)
                {

                    return RedirectToAction("Create", "User");
                }
                String result = dao.Insert(ngDung);
                if (!String.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm người dùng không thành công");
                }
            }
            return View();
        }

      
       public ActionResult Edit(NGUOIDUNG ngDung)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                
                var result = dao.Update(ngDung);
                if (result)
                {
                    SetAlert("Cập người người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật người dùng không thành công");
                }
            }
            return View();
        }
        
        public ActionResult Delete(string TenDangNhap)
        {
            new UserDAO().Delete(TenDangNhap);
            SetAlert("Xoá thành công", "success");
            return RedirectToAction("Index","User");
        }
    }
}