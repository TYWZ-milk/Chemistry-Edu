using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chemistry_Education.Models;
using System.Runtime.InteropServices;
namespace Chemistry_Education.Controllers
{
    public class InfoController : Controller
    {

        // GET: Info
        [HttpPost]
        public ActionResult Info(HttpPostedFileBase file)
        {

            HttpCookie cook = Request.Cookies["temp"];
            String cookie = cook["userid"];
            int studentID = int.Parse(cookie);
            Model1 head = new Model1();
            var headquery = (from s in head.student where s.StudentID == studentID select s).FirstOrDefault();
            ViewBag.head = headquery.Head;
            String name = Request["name"];
            String major = Request["major"];
            String grade = Request["grade"];
            String description = Request["description"];

            if (name != null || major != null || grade != null || description != null || Request.Files.Count>0)
            {
                Model1 ctxx = new Model1();
                var update = (from s in ctxx.student where s.StudentID == studentID select s).FirstOrDefault();

                if (name != "")
                    update.Name = name;
                if (major != "")
                    update.Major = major;
                if (grade != "")
                    update.Grade = grade;
                if (description != "")
                    update.Description = description;
                if (Request.Files["imgPicker"].ContentLength != 0)
                {
                    HttpPostedFileBase f = Request.Files["imgPicker"];
                    string new_path = Server.MapPath("~/Content/images/");
                    f.SaveAs(new_path + f.FileName);
                    string store_path = "/Content/images/";
                    update.Head = store_path + f.FileName;
                }
                ctxx.SaveChanges();
            }

            Model1 ctx = new Model1();
            var query = from s in ctx.student where s.StudentID == studentID select new { s.StudentID, s.Head, s.Name, s.Grade, s.Major, s.Description };

            foreach (var item in query)
            {
                ViewBag.Head = item.Head;
                ViewBag.StudentID = item.StudentID;
                ViewBag.Name = item.Name;
                ViewBag.Grade = item.Grade;
                ViewBag.Major = item.Major;
                ViewBag.Description = item.Description;
            }


            return View();
        }
        public ActionResult Info()
        {
            HttpCookie cook = Request.Cookies["temp"];
            String cookie = cook["userid"];
            int studentID = int.Parse(cookie);
            Model1 head = new Model1();
            var headquery = (from s in head.student where s.StudentID == studentID select s).FirstOrDefault();
            ViewBag.head = headquery.Head;
            String picture = "/Content/images/avatar.jpg";
            String name = Request["name"];
            String major = Request["major"];
            String grade = Request["grade"];
            String description = Request["description"];

            if (name != null || major != null || grade != null || description != null)
            {
                Model1 ctxx = new Model1();
                var update = (from s in ctxx.student where s.StudentID == studentID select s).FirstOrDefault();
                update.Head = picture;
                if(name != "")
                    update.Name = name;
                if(major != "")
                    update.Major = major;
                if(grade != "")
                    update.Grade = grade;
                if(description != "")
                    update.Description = description;

                ctxx.SaveChanges();
            }

            Model1 ctx = new Model1();
            var query = from s in ctx.student where s.StudentID == studentID select new {s.StudentID, s.Head, s.Name, s.Grade, s.Major, s.Description };

            foreach (var item in query)
            {
                ViewBag.Head = item.Head;
                ViewBag.StudentID = item.StudentID;
                ViewBag.Name = item.Name;
                ViewBag.Grade = item.Grade;
                ViewBag.Major = item.Major;
                ViewBag.Description = item.Description;
            }


            return View();
        }
        public ActionResult ChangeInfo()
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