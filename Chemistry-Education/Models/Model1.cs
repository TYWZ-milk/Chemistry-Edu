namespace Chemistry_Education.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {

        public class userHome
        {
            public int ClassID { get; set; }

            public string ClassName { get; set; }

            public string Teacher { get; set; }

            public string Phone { get; set; }

            public string RS { get; set; }

            public string TE { get; set; }

            public string Textbook { get; set; }

            public string Time { get; set; }

            public string Description { get; set; }

            public string password { get; set; }

            public int Elective { get; set; }

            public int Limit { get; set; }

        }
        public class Article
        {
            public string ArticleID { get; set; }

            public string Title { get; set; }

            public string Brief { get; set; }

            public string Content { get; set; }

            public string Picture { get; set; }

        }
        public class Comment
        {
            public string CommentID { get; set; }

            public string Content { get; set; }

            public string studentID { get; set; }

            public string datetime { get; set; }

            public string name { get; set; }

            public string Picture { get; set; }

        }


        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<article> article { get; set; }
        public virtual DbSet<article_comment> article_comment { get; set; }
        public virtual DbSet<class_student> class_student { get; set; }
        public virtual DbSet<classes> classes { get; set; }
        public virtual DbSet<comment> comment { get; set; }
        public virtual DbSet<student> student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<article>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<article>()
                .Property(e => e.Brief)
                .IsUnicode(false);

            modelBuilder.Entity<article>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<article>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<classes>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<classes>()
                .Property(e => e.Teacher)
                .IsUnicode(false);

            modelBuilder.Entity<classes>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<classes>()
                .Property(e => e.RS)
                .IsUnicode(false);

            modelBuilder.Entity<classes>()
                .Property(e => e.TE)
                .IsUnicode(false);

            modelBuilder.Entity<classes>()
                .Property(e => e.Textbook)
                .IsUnicode(false);

            modelBuilder.Entity<classes>()
                .Property(e => e.Time)
                .IsUnicode(false);

            modelBuilder.Entity<classes>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<comment>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<comment>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.Head)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.Grade)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.Major)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
