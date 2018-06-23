using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chemistry_Education.Models;
using System.Runtime.InteropServices;
namespace Chemistry_Education.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        [DllImport("StringProcess.dll")]
        public static extern int mytoInt(string str);
        public ActionResult Calendar()
        {

            HttpCookie cook = Request.Cookies["temp"];
            String cookie = cook["userid"];
            int studentID = int.Parse(cookie);
            Model1 ctx = new Model1();
            var query = (from s in ctx.student where s.StudentID == studentID select s).FirstOrDefault();
            ViewBag.head = query.Head;

            return View();
        }
    }
}