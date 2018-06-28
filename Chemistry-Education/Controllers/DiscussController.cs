using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chemistry_Education.Models;
using System.Runtime.InteropServices;
using COM.Interop;
using System.Threading.Tasks;
using System.Threading;

namespace Chemistry_Education.Controllers
{
    public class DiscussController : Controller
    {
        [DllImport("Win32 DLL.dll")]
        public static extern int addOne(int ID);
        [DllImport("BasicOperation.dll")]
        public static extern int mytoInt(string str);
        // GET: Discuss

        [HttpPost]
        public ActionResult Article(HttpPostedFileBase file)
        {

            HttpCookie cook = Request.Cookies["temp"];
            String cookie = cook["userid"];
            int studentID = int.Parse(cookie);
            Model1 head = new Model1();
            var headquery = (from s in head.student where s.StudentID == studentID select s).FirstOrDefault();
            ViewBag.head = headquery.Head;
            //新帖子
            string newtitle = Request["newtitle"];
            string newbrief = Request["newbrief"];
            string newcontent = Request["newcontent"];
            int newarticleid = 0;
            if (newtitle != null)
            {
                Model1 newData = new Model1();
                var articleCount = from s in newData.article select s;
                var newarticle = new article();
                FirstComObj temp = new FirstComObj();
                newarticle.articleID = temp.AddOne_COM(articleCount.Count());
                //newarticle.articleID = addOne(articleCount.Count());
                newarticleid = newarticle.articleID;
                newarticle.Content = newcontent;
                newarticle.Brief = newbrief;
                newarticle.Title = newtitle;

                HttpPostedFileBase f = Request.Files["imgPicker"];
                string new_path = Server.MapPath("~/Content/images/");
                f.SaveAs(new_path + f.FileName);
                string store_path = "/Content/images/";
                newarticle.Picture = store_path + f.FileName;

                newData.article.Add(newarticle);
                newData.SaveChanges();
            }


            //
            //新评论
            string newComment = Request["comment"];
            string articleID = Request["articleID"];
            int ArticleID = 0;
            if (articleID != null)
                ArticleID = int.Parse(articleID);
            else
                ArticleID = newarticleid;

            if (newComment != null)
            {
                Model1 commentData = new Model1();
                var commentCount = from s in commentData.comment select s;
                var comment = new comment();
                comment.commentID = addOne(commentCount.Count());
                comment.Content = newComment;
                DateTime dt = DateTime.Now;
                string str = dt.ToString("yyyy-MM-dd HH:mm:ss");
                comment.date = str;
                comment.StudentID = studentID;
                commentData.comment.Add(comment);
                

                var comment_article = new article_comment();
                comment_article.commentID = addOne(commentCount.Count());
                comment_article.articleID = ArticleID;
                commentData.article_comment.Add(comment_article);
                commentData.SaveChanges();
            }


            //显示文章
            Model1 ctx = new Model1();
            var query = (from s in ctx.article where s.articleID == ArticleID select s).FirstOrDefault();
            ViewBag.content = query.Content;
            ViewBag.brief = query.Brief;
            ViewBag.theme = query.Title;
            ViewBag.Title = query.Title;
            ViewBag.picture = query.Picture;

            //显示评论
            Model1 ctxx = new Model1();
            var comments = from s in ctxx.article_comment where s.articleID == ArticleID select new { s.commentID };
            var commentHome = new List<Comment>();
            foreach (var item in comments.ToList())
            {

                var commentContent = (from s in ctx.comment where s.commentID == item.commentID select s).FirstOrDefault();
                var commentUser = (from s in ctx.student where s.StudentID == commentContent.StudentID select s).FirstOrDefault();

                commentHome.Add(new Comment { Content = commentContent.Content, datetime = commentContent.date, name = commentUser.Name, Picture = commentUser.Head });
            }
            ViewBag.commentHome = commentHome;
            ViewBag.commentNumber = commentHome.Count();
            ViewBag.htmlHref = "Article?articleID=" + articleID + "";

            return View();
        }
        public ActionResult Discuss()
        {

            HttpCookie cook = Request.Cookies["temp"];
            String cookie = cook["userid"];
            int studentID = int.Parse(cookie);
            Model1 head = new Model1();
            var headquery = (from s in head.student where s.StudentID == studentID select s).FirstOrDefault();
            ViewBag.head = headquery.Head;

            Model1 ctx = new Model1();
            var articles = (from s in ctx.article select s);
            var Article = new List<Article>();
            foreach (var item in articles.ToList())
            {
                String htmlID = "Article?articleID="+item.articleID+"";
                Article.Add(new Article { ArticleID = htmlID, Brief = item.Brief, Content = item.Content, Title = item.Title, Picture = item.Picture });
            }
            ViewBag.Article = Article;
            return View();
        }

        public delegate void MyDelegate(int ArticleID);
        void Task1(int ArticleID)
        {
            Model1 ctx = new Model1();
            var query = (from s in ctx.article where s.articleID == ArticleID select s).FirstOrDefault();
            ViewBag.content = query.Content;
            ViewBag.brief = query.Brief;
            ViewBag.theme = query.Title;
            ViewBag.Title = query.Title;
            ViewBag.picture = query.Picture;
        }
        void Task2(int ArticleID)
        {
            Model1 ctx = new Model1();
            Model1 ctxx = new Model1();
            var comments = from s in ctxx.article_comment where s.articleID == ArticleID select new { s.commentID };
            var commentHome = new List<Comment>();
            foreach (var item in comments.ToList())
            {

                var commentContent = (from s in ctx.comment where s.commentID == item.commentID select s).FirstOrDefault();
                var commentUser = (from s in ctx.student where s.StudentID == commentContent.StudentID select s).FirstOrDefault();

                commentHome.Add(new Comment { Content = commentContent.Content, datetime = commentContent.date, name = commentUser.Name, Picture = commentUser.Head });
            }
            ViewBag.commentHome = commentHome;
            ViewBag.commentNumber = commentHome.Count();

        }
        private static int backcall(int parameter)
         {
             //System.Windows.Forms.MessageBox.Show("这是一个回调函数");
             return 0;
         
         }
        public ActionResult Article()
        {
            HttpCookie cook = Request.Cookies["temp"];
            String cookie = cook["userid"];
            int studentID = int.Parse(cookie);
            Model1 head = new Model1();
            var headquery = (from s in head.student where s.StudentID == studentID select s).FirstOrDefault();
            ViewBag.head = headquery.Head;
            //新帖子
            string newtitle = Request["newtitle"];
            string newbrief = Request["newbrief"];
            string newcontent = Request["newcontent"];
            int newarticleid = 0;
            if(newtitle != null)
            {
                Model1 newData = new Model1();
                var articleCount = from s in newData.article select s;
                var newarticle = new article();
                newarticle.articleID = addOne(articleCount.Count());
                newarticleid = newarticle.articleID;
                newarticle.Content = newcontent;
                newarticle.Brief = newbrief;
                newarticle.Title = newtitle;
                newData.article.Add(newarticle);
                newData.SaveChanges();
            }


            //
            //新评论
            string newComment = Request["comment"];
            string articleID = Request["articleID"];
            int ArticleID = 0;
            if (articleID != null)
                ArticleID = int.Parse(articleID);
            else
                ArticleID = newarticleid;

            if (newComment != null)
            {
                Model1 commentData = new Model1();
                var commentCount = from s in commentData.comment select s;
                var comment = new comment();
                comment.commentID = addOne(commentCount.Count());
                comment.Content = newComment;
                DateTime dt = DateTime.Now;
                string str = dt.ToString("yyyy-MM-dd HH:mm:ss");
                comment.date = str;
                comment.StudentID = studentID;
                commentData.comment.Add(comment);
;

                var comment_article = new article_comment();
                comment_article.commentID = addOne(commentCount.Count());
                comment_article.articleID = ArticleID;
                commentData.article_comment.Add(comment_article);
                commentData.SaveChanges();
            }

            MyDelegate dele = new MyDelegate(Task1);
            //dele.BeginInvoke(ArticleID,backcall,"我是异步调用的parameter");
            dele += new MyDelegate(Task2);
            dele(ArticleID);

            //显示文章
            //Model1 ctx = new Model1();
            //var query = (from s in ctx.article where s.articleID == ArticleID select s).FirstOrDefault();
            //ViewBag.content = query.Content;
            //ViewBag.brief = query.Brief;
            //ViewBag.theme = query.Title;
            //ViewBag.Title = query.Title;
            //ViewBag.picture = query.Picture;

            ////显示评论
            //Model1 ctxx = new Model1();
            //var comments = from s in ctxx.article_comment where s.articleID == ArticleID select new { s.commentID };
            //var commentHome = new List<Comment>();
            //foreach (var item in comments.ToList())
            //{

            //    var commentContent = (from s in ctx.comment where s.commentID == item.commentID select s).FirstOrDefault();
            //    var commentUser = (from s in ctx.student where s.StudentID == commentContent.StudentID select s).FirstOrDefault();

            //    commentHome.Add(new Comment { Content = commentContent.Content, datetime = commentContent.date, name = commentUser.Name, Picture = commentUser.Head});
            //}
            //ViewBag.commentHome = commentHome;
            //ViewBag.commentNumber = commentHome.Count();
            ViewBag.htmlHref = "Article?articleID=" + articleID + "";
           
            return View();
        }
        public ActionResult NewArticle()
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