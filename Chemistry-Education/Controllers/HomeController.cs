using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chemistry_Education.Models;
using System.Runtime.InteropServices;
using COM.Interop;
using Operation;
namespace Chemistry_Education.Controllers
{
    public class HomeController : Controller
    {
        [DllImport("Win32 DLL.dll")]
        public static extern int compare(int a, int b);
        [DllImport("Win32 DLL.dll")]
        public static extern int ErrorMessage(int type, ref byte str);
        [DllImport("BasicOperation.dll")]
        public static extern int  mytoInt(string str);
        [DllImport("BasicOperation.dll")]
        public static extern string mytoStr(int num);


        public ActionResult Login()
        {
            string userid = Request["ID"];
            string password = Request["password"];
            string repassword = Request["repassword"];

            if (userid != null)
            {
                int studentID = int.Parse(userid);
     
                if (compare(int.Parse(password),int.Parse(repassword))==0)
                {
                    Model1 ctxx = new Model1();
                    var query = (from s in ctxx.student where s.StudentID == studentID select s).FirstOrDefault();
                    if (query == null)
                    {
                        Model1 ctx = new Model1();
                        var user = new student();
                        user.StudentID = int.Parse(userid);
                        user.Password = password;
                        ctx.student.Add(user);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        byte[] s = new byte[1024];
                        int t = ErrorMessage(0,ref s[0]);//用字节数组接收动态库传过来的字符串
                        string message = System.Text.Encoding.Default.GetString(s, 0, s.Length);
                        return Content(message);
                    }
                }
                else
                {
                    byte[] s = new byte[1024];
                    int t = ErrorMessage(1, ref s[0]);//用字节数组接收动态库传过来的字符串
                    string message = System.Text.Encoding.Default.GetString(s, 0, s.Length);
                    return Content(message);
                }
            }
            return View();

        }

        public ActionResult ManageLogin()
        {
            return View();
        }
    }
}
