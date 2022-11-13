﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BLACKMONSTER\\SQLEXPRESS;database=CoreBlogDb; integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.SenderUserInfo)
                .HasForeignKey(x => x.SenderUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.ReceiverUserInfo)
                .HasForeignKey(x => x.ReceiverUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<NewsLetter> NewsLetters { get; set; }
        public virtual DbSet<BlogRayting> BlogRaytings { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageDraft> MessagesDrafts { get; set; }
        public virtual DbSet<NewsLetterDraft> NewsLetterDrafts { get; set; }
    }
}
