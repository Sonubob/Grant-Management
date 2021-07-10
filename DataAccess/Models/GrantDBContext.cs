using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GrantManagement.Models
{
    public partial class GrantDBContext : DbContext
    {
        public GrantDBContext()
        {
        }

        public GrantDBContext(DbContextOptions<GrantDBContext> options)
            : base(options)
        {
         //   Database.SetInitializer(new MigrateDatabaseToLatestVersion<
         //GrantDBContext, DataAccess.Migrations>("MyContextDB"));

        }

        public virtual DbSet<ApplicantDetail> ApplicantDetails { get; set; }
        public virtual DbSet<EducationalDetail> EducationalDetails { get; set; }
        public virtual DbSet<GrantProgram> GrantPrograms { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<CountryLookup> CountryLookups { get; set; }
        public virtual DbSet<StateLookup> StateLookups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=laptop;Database=GrantDB;Trusted_Connection=True;");
           
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicantDetail>(entity =>
            {
                entity.HasKey(e => e.ApplicantId);

                entity.ToTable("ApplicantDetail");

                entity.Property(e => e.ApplicantId).UseIdentityColumn();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PostCode).HasMaxLength(50);

                entity.Property(e => e.ApplicationStatus).HasMaxLength(50);

                entity.Property(e => e.ReviewStatus).HasColumnType("bit");

                entity.HasOne(x => x.UserInfo)
                      .WithOne(x => x.ApplicantDetail)
                      .HasForeignKey<ApplicantDetail>(x => x.UserId);

                entity.HasOne(s => s.GrantProgram)
                      .WithMany(g => g.ApplicantDetails)
                      .HasForeignKey(s => s.GrantId);

            });

            modelBuilder.Entity<EducationalDetail>(entity =>
            {
                entity.ToTable("EducationalDetail");

                entity.Property(e => e.EducationalDetailId).UseIdentityColumn();

                entity.Property(e => e.ApplicantId).HasColumnType("int");

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.Institution).HasMaxLength(50);

                entity.Property(e=>e.Country).HasColumnType("int");
                entity.Property(e=>e.CompletionYear).HasColumnType("int");
                

            });

            modelBuilder.Entity<GrantProgram>(entity =>
            {
                entity.HasKey(e => e.GrantId);

                entity.ToTable("GrantProgram");

                entity.Property(e => e.GrantId).UseIdentityColumn();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProgramCode).HasMaxLength(50);

                entity.Property(e => e.ProgramName).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnType("bit");

                entity.HasMany<ApplicantDetail>(g => g.ApplicantDetails)
                      .WithOne(s => s.GrantProgram)
                      .HasForeignKey(z=>z.GrantId);

            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserInfo");

                entity.Property(e => e.UserId).UseIdentityColumn();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(x => x.ApplicantDetail)
                     .WithOne(x => x.UserInfo)
                      .HasForeignKey<ApplicantDetail>(x => x.UserId);
            });

            modelBuilder.Entity<CountryLookup>(entity =>
            {
                entity.ToTable("CountryLookup").HasNoKey();

                entity.Property(e => e.CountryId).ValueGeneratedOnAdd();

              

                entity.Property(e => e.CountryName).HasMaxLength(50);

              


            });
            modelBuilder.Entity<StateLookup>(entity =>
            {
                entity.ToTable("StateLookup").HasNoKey();
                

                entity.Property(e => e.StateId).ValueGeneratedOnAdd();



                entity.Property(e => e.StateName).HasMaxLength(50);
                entity.Property(e => e.CountryId).HasColumnType("numeric(18, 0)");





            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
