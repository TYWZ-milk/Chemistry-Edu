using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chemistry_Education.Models;
using System.Runtime.InteropServices;
namespace Chemistry_Education.Controllers
{
    public class MolecularGraphController : Controller
    {
        [DllImport("StringProcess.dll")]
        public static extern int mytoInt(string str);
        // GET: MolecularGraph
        public ActionResult Chemicaltable()
        {
            HttpCookie cook = Request.Cookies["temp"];
            String cookie = cook["userid"];
            int studentID = int.Parse(cookie);
            Model1 head = new Model1();
            var headquery = (from s in head.student where s.StudentID == studentID select s).FirstOrDefault();
            ViewBag.head = headquery.Head;
            return View();
        }
        public ActionResult Molecules()
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