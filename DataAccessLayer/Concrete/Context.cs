using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =SYSTEMOFADOWN\\SQLEXPRESS ; database = CoreBlogDB ; integrated security = true ;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityLayer.Concrete.Match>()
                .HasOne(x => x.HomeTeam)
                .WithMany(y => y.HomeMatches)
                .HasForeignKey(z => z.HomeTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EntityLayer.Concrete.Match>()
                .HasOne(x => x.GuestTeam)
                .WithMany(y => y.AwayMatches)
                .HasForeignKey(z => z.GuestTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // HomeMatches => WriterSender
            // AwayMatches => WriterReceiver

            // HomeTeam => SenderUser
            // GuestTeam => ReceiverUser

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLatter> NewsLatters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notificationss { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<EntityLayer.Concrete.Match> Matches { get; set; }
        public DbSet<Message> Messages2s { get; set; }


    }
}
