using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        ruankaoEntities1 db = new ruankaoEntities1();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        #region 登陆操作
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "UserName,Password")]UserInfo users)
        {
            if (ModelState.IsValid)
            {


                var result = from u in db.UserInfo
                             where u.UserName == users.UserName && u.Password == users.Password
                             select u;
                if (result.Count() > 0)
                {
                    Session["UserName"] = users.UserName;
                    return Redirect(Url.Action("Index", "Home"));
                }
                else
                {
                    return Content("<script>alert('用户名或密码错误！');window.open('" + Url.Content("~/Users/Login") + "', '_self')</script>");
                }
            }
            else
            {
                return Content("<script>alert('用户名或密码错误！');window.open('" + Url.Content("~/Users/Login") + "', '_self')</script>");
            }
        }
        #region 注册操作

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserInfo user)
        {
            var username = from users in db.UserInfo
                           where users.UserName == user.UserName
                           select users;
            db.Set<UserInfo>().Add(user);
            db.SaveChanges();
            return Content("<script>alert('注册成功！');window.open('" + Url.Content("~/Users/Login") + "','_self');</script>");
        }
        #endregion
        #region 用户名检测
        [HttpPost]
        public string CheckUser(string UserName)
        {
            if (UserName != "")
            {

                var result = from user in db.UserInfo
                             where user.UserName == UserName
                             select user;
                if (result.Count() > 0)
                {
                    return "抱歉，该用户名已存在！";
                }
                else
                {
                    return "恭喜，该用户名可以注册！";
                }
            }
            else
            {
                return "用户名不能为空！";
            }
        }
        #endregion
    }
    #endregion
} 