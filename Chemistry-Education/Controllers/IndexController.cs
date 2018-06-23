using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chemistry_Education.Models;
using System.Runtime.InteropServices;
namespace Chemistry_Education.Controllers
{
    public class IndexController : Controller
    {
        [DllImport("StringProcess.dll")]
        public static extern int mytoInt(string str);
        // GET: Index
        public ActionResult Index()
        {
            string userid = Request["ID"];
            string password = Request["password"];
            if (userid != null)
            {
                int studentID = int.Parse(userid);
                Model1 ctx = new Model1();
                var query = (from s in ctx.student where s.StudentID == studentID select s).FirstOrDefault();
                if (query.Password == password)
                {

                    ViewBag.head = query.Head;
                    HttpCookie cookie = new HttpCookie("temp");
                    cookie.Values.Add("userid", userid);
                    Response.Cookies.Add(cookie);

                    return View();
                }
                else
                {
                    return Content("<script>alert('账号密码输入错误');history.go(-1);</script>");

                }
            }
            else
            {
                HttpCookie cook = Request.Cookies["temp"];
                String cookie = cook["userid"];
                int studentID = int.Parse(cookie);
                Model1 head = new Model1();
                var headquery = (from s in head.student where s.StudentID == studentID select s).FirstOrDefault();
                ViewBag.head = headquery.Head;
                return View();
            }
        }
    }
}