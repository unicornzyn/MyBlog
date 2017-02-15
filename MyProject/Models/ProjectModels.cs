namespace MyProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectModels : DbContext
    {
        public ProjectModels()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<R_ArticleTags> R_ArticleTags { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.contenthtml)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<Reply>()
                .Property(e => e.Nick)
                .IsUnicode(false);

            modelBuilder.Entity<Reply>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Tags>()
                .Property(e => e.tname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Passwd)
                .IsUnicode(false);
        }
    }
}
