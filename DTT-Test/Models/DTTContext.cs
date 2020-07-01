using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace DTT_Test.Models
{
    public class DTTContext : DbContext
    {
        public DTTContext( DbContextOptions<DTTContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Article>(entity =>
            //{
            //    entity.ToTable("Article");

            //    entity.HasIndex(e => e.Id)
            //        .HasName("id_UNIQUE")
            //        .IsUnique();

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasColumnType("int(11)");

            //    entity.Property(e => e.Summary)
            //        .IsRequired()
            //        .HasColumnName("summary")
            //        .HasMaxLength(150)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasColumnName("description")
            //        .HasMaxLength(225)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PublishDate)
            //        .HasColumnName("publishDate")
            //        .HasColumnType("date");

            //    entity.Property(e => e.Title)
            //        .IsRequired()
            //        .HasColumnName("title")
            //        .HasMaxLength(80)
            //        .IsUnicode(false);
            //});
        }
    }
}
