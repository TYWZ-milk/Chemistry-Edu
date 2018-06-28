using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chemistry_Education.Models;
using System.Runtime.InteropServices;
using Operation;
namespace Chemistry_Education.Controllers
{
    public class IndexController : Controller
    {
        [DllImport("StringProcess.dll")]
        public static extern int mytoInt(string str);
        [DllImport("Win32 DLL.dll")]
        public static extern int ErrorMessage(int type, ref byte str);
        // GET: Index
        public ActionResult Index()
        {
            string userid = Request["ID"];
            string password = Request["password"];
            if (userid != null)
            {
                Operation.operation operation = new Operation.operation();

                int studentID = operation.mytoInt(userid);
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
                    byte[] s = new byte[1024];
                    int t = ErrorMessage(2, ref s[0]);//用字节数组接收动态库传过来的字符串
                    string message = System.Text.Encoding.Default.GetString(s, 0, s.Length);
                    return Content(message);

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
                ViewBag.Title = "首页";
                return View();
            }
        }
    }
}