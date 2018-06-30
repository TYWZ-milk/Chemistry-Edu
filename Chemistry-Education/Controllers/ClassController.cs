using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chemistry_Education.Models;
using System.Runtime.InteropServices;
using static Chemistry_Education.Models.Model1;
namespace Chemistry_Education.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        [DllImport("StringProcess.dll")]
        public static extern int mytoInt(string str);
        public ActionResult Class()
        {
            HttpCookie cook = Request.Cookies["temp"];
            String cookie = cook["userid"];
            int studentID = int.Parse(cookie);
            Model1 head = new Model1();
            var headquery = (from s in head.student where s.StudentID == studentID select s).FirstOrDefault();
            ViewBag.head = headquery.Head;
            

            string classID = Request["classID"];
            if (classID != null)
            {
                int newclassID = mytoInt(classID);
                Model1 classesModel = new Model1();
                var oldClasses = from s in classesModel.class_student where s.StudentID == studentID select new { s.ClassID };
                foreach(var item in oldClasses.ToList())
                {
                    if(item.ClassID == newclassID)
                    {
                        return Content("<script>alert('您已选择该课程');history.go(-1);</script>");
                    }
                }
                var fullclasses = (from s in classesModel.classes where s.ClassID == newclassID select s).FirstOrDefault();
                if(fullclasses.Elective+1 > fullclasses.Limit)
                {
                    return Content("<script>alert('课程人数已达到上限，无法选择该课程');history.go(-1);</script>");
                }
                else
                {
                    fullclasses.Elective++;
                    classesModel.SaveChanges();
                }
                int classid = int.Parse(classID);
                Model1 ctxx = new Model1();
                var user = new class_student();
                user.ClassID = classid;
                user.StudentID = studentID;
                ctxx.class_student.Add(user);
                ctxx.SaveChanges();
            }

            Model1 ctx = new Model1();
            var classes = from s in ctx.class_student where s.StudentID == studentID select new { s.ClassID };
            var userHome = new List<userHome>();
            foreach (var item in classes.ToList())
            {

                var query = (from s in ctx.classes where s.ClassID == item.ClassID select s).FirstOrDefault();


                userHome.Add(new userHome { ClassID = query.ClassID, ClassName = query.ClassName, Teacher = query.Teacher, Phone = query.Phone, RS = query.RS, TE = query.TE, Textbook = query.Textbook, Time = query.Time, Description = query.Description, Limit = query.Limit.Value, Elective = query.Elective.Value });
            }
            ViewBag.userHome = userHome;
            return View();
        }

        public ActionResult ChangeClass()
        {
            HttpCookie cook = Request.Cookies["temp"];
            String cookie = cook["userid"];
            int studentID = int.Parse(cookie);
            Model1 head = new Model1();
            var headquery = (from s in head.student where s.StudentID == studentID select s).FirstOrDefault();
            ViewBag.head = headquery.Head;

            Model1 ctx = new Model1();
            var classes = (from s in ctx.classes select s);
            var userHome = new List<userHome>();
            foreach (var item in classes.ToList())
            {
                userHome.Add(new userHome { ClassID = item.ClassID, ClassName = item.ClassName, Teacher = item.Teacher, Phone = item.Phone, RS = item.RS, TE = item.TE, Textbook = item.Textbook, Time = item.Time, Description = item.Description, Limit = item.Limit.Value, Elective = item.Elective.Value });
            }
            ViewBag.userHome = userHome;
            return View();
        }


    }
}