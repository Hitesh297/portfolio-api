using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Portfolio.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ContactForm> ContactForms => Set<ContactForm>();
        public DbSet<Content> Contents => Set<Content>();
        public DbSet<Experience> Experiences => Set<Experience>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Qualification> Qualifications => Set<Qualification>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<SocialMedia> SocialMedias => Set<SocialMedia>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // -------------------------
            // contactforms
            // -------------------------
            modelBuilder.Entity<ContactForm>(entity =>
            {
                entity.ToTable("contactforms");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);
            });

            // -------------------------
            // contents
            // -------------------------
            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("contents");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                // Column name is "content" in DB, property is ContentText in C#
                entity.Property(e => e.ContentText)
                    .HasColumnName("contentText")
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);
            });

            // -------------------------
            // experiences
            // -------------------------
            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("experiences");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Responsibilities)
                    .HasColumnName("responsibilities")
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                // If you're using DateOnly (EF Core 8 supports it)
                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date")
                    .IsRequired();
            });

            // -------------------------
            // projects
            // -------------------------
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("projects");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("nvarchar(max)")
                    .IsRequired();

                entity.Property(e => e.Technologies)
                    .HasColumnName("technologies")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.GitUrl)
                    .HasColumnName("gitUrl")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LiveUrl)
                    .HasColumnName("liveUrl")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence")
                    .IsRequired();
            });

            // -------------------------
            // qualifications
            // -------------------------
            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.ToTable("qualifications");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Credential)
                    .HasColumnName("credential")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.YearCompleted)
                    .HasColumnName("yearCompleted")
                    .IsRequired();
            });

            // -------------------------
            // skills
            // -------------------------
            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skills");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence")
                    .IsRequired();

                // DB column is fontawesomeHTML, property is FontawesomeHtml
                entity.Property(e => e.FontawesomeHtml)
                    .HasColumnName("fontawesomeHTML")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);
            });

            // -------------------------
            // socialmedias
            // -------------------------
            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.ToTable("socialmedias");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(191)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence")
                    .IsRequired();
            });

            // -------------------------
            // users
            // -------------------------

            base.OnModelCreating(modelBuilder);
        }
    }
}
