using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chemistry_Education.Models;
using System.Runtime.InteropServices;
using Operation;
using static Chemistry_Education.Models.Model1;
namespace Chemistry_Education.Controllers
{
    public class ManageController : Controller
    {
        [DllImport("StringProcess.dll")]
        public static extern int mytoInt(string str);
        [DllImport("Win32 DLL.dll")]
        public static extern int ErrorMessage(int type, ref byte str);
        // GET: Manage
        public ActionResult ManageIndex()
        {

            string userid = Request["ID"];
            string password = Request["password"];
            if (userid != null)
            {
                if (userid == "1552662")
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
                    return Content("<script>alert('该账号为非管理员账号');history.go(-1);</script>");
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
                ViewBag.Title = "管理员首页";
                return View();
            }
        }

        public ActionResult ManageClass()
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

        public ActionResult ClassInfo()
        {
            string classid = Request["classID"];
            int classID = int.Parse(classid);
            Model1 ctx = new Model1();
            var query = (from s in ctx.classes where s.ClassID == classID select s).FirstOrDefault();


            ViewBag.ClassID = query.ClassID;
            ViewBag.ClassName = query.ClassName;
            ViewBag.Elective = query.Elective;
            ViewBag.Limit = query.Limit;
            ViewBag.Phone = query.Phone;
            ViewBag.Description = query.Description;
            ViewBag.Teacher = query.Teacher;
            ViewBag.RS = query.RS;
            ViewBag.TE = query.TE;
            ViewBag.Textbook = query.Textbook;
            ViewBag.Time = query.Time;
            return View();
        }

        public ActionResult ChangeClassInfo()
        {
            string classid = Request["classID"];
            ViewBag.classid = classid;
            return View();
        }

        [HttpPost]
        public ActionResult ClassInfo(HttpPostedFileBase file)
        {

            string classid = Request["classID"];
            int classID = int.Parse(classid);
            String classname = Request["classname"];
            String description = Request["description"];
            String teacher = Request["teacher"];
            String phone = Request["phone"];
            String time = Request["time"];
            String RS = Request["RS"];
            String TE = Request["TE"];
            String textbook = Request["textbook"];
            String limit = Request["limit"];
            if (classname != null || description != null || teacher != null || phone != null||time!=null ||RS!=null||TE!=null||textbook!=null||limit!=null)
            {
                Model1 ctxx = new Model1();
                var update = (from s in ctxx.classes where s.ClassID == classID select s).FirstOrDefault();

                if (classname != "")
                    update.ClassName = classname;
                if (description != "")
                    update.Description = description;
                if (teacher != "")
                    update.Teacher = teacher;
                if (phone != "")
                    update.Description = description;
                if (time != "")
                    update.Time = time;
                if (RS != "")
                    update.RS = RS;
                if (TE != "")
                    update.TE = TE;
                if (textbook != "")
                    update.Textbook = textbook;
                if (textbook != "")
                    update.Limit = int.Parse(limit);
                ctxx.SaveChanges();
            }

            Model1 ctx = new Model1();
            var query = (from s in ctx.classes where s.ClassID == classID select s).FirstOrDefault();


            ViewBag.ClassID = query.ClassID;
            ViewBag.ClassName = query.ClassName;
            ViewBag.Elective = query.Elective;
            ViewBag.Limit = query.Limit;
            ViewBag.Phone = query.Phone;
            ViewBag.Description = query.Description;
            ViewBag.Teacher = query.Teacher;
            ViewBag.RS = query.RS;
            ViewBag.TE = query.TE;
            ViewBag.Textbook = query.Textbook;
            ViewBag.Time = query.Time;


            return View();
        }
    }
}