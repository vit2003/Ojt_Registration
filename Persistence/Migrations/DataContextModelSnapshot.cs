﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("ntext")
                        .HasColumnName("address");

                    b.Property<string>("CompanyName")
                        .HasColumnType("ntext")
                        .HasColumnName("company_name");

                    b.Property<string>("HostManagerEmail")
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("HostManagerEmail");

                    b.Property<string>("WebSite")
                        .HasColumnType("text")
                        .HasColumnName("web_site");

                    b.HasKey("Id");

                    b.ToTable("tbl_company");
                });

            modelBuilder.Entity("Domain.CompanyAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyAccounts");
                });

            modelBuilder.Entity("Domain.FptStaff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("email");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasColumnName("fullname");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tbl_fpt_staff");
                });

            modelBuilder.Entity("Domain.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MajorName")
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("major_name");

                    b.HasKey("Id");

                    b.ToTable("tbl_major");
                });

            modelBuilder.Entity("Domain.OjtReports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("company_id");

                    b.Property<string>("Division")
                        .HasColumnType("ntext")
                        .HasColumnName("division");

                    b.Property<string>("LineManagerName")
                        .HasColumnType("ntext")
                        .HasColumnName("line_manager_name");

                    b.Property<double?>("Mark")
                        .HasColumnType("float")
                        .HasColumnName("mark");

                    b.Property<int?>("OnWorkDate")
                        .HasColumnType("int")
                        .HasColumnName("on_work_date");

                    b.Property<DateTime?>("Public_Date")
                        .HasColumnType("datetime")
                        .HasColumnName("public_date");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("student_id");

                    b.Property<string>("WorkSortDescription")
                        .HasColumnType("ntext")
                        .HasColumnName("work_sort_description");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StudentId");

                    b.ToTable("tbl_ojt_report");
                });

            modelBuilder.Entity("Domain.RecruimentApply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverLetter")
                        .HasColumnType("ntext")
                        .HasColumnName("cover_letter");

                    b.Property<string>("Cv")
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("cv");

                    b.Property<int?>("RecruimentInformationId")
                        .HasColumnType("int")
                        .HasColumnName("recruiment_information_id");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("registration_date");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("student_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("RecruimentInformationId");

                    b.HasIndex("StudentId");

                    b.ToTable("tbl_recruiment_apply");
                });

            modelBuilder.Entity("Domain.RecruitmentInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("ntext")
                        .HasColumnName("area");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("company_id");

                    b.Property<string>("Content")
                        .HasColumnType("ntext")
                        .HasColumnName("content");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime")
                        .HasColumnName("deadline");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MajorId")
                        .HasColumnType("int")
                        .HasColumnName("major_id");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salary")
                        .HasColumnType("ntext")
                        .HasColumnName("salary");

                    b.Property<string>("Topic")
                        .HasColumnType("ntext")
                        .HasColumnName("topic");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("tbl_recruitment_information");
                });

            modelBuilder.Entity("Domain.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRevorked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("JwtId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Domain.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime")
                        .HasColumnName("birthday");

                    b.Property<bool>("CanSendApplication")
                        .HasColumnType("bit");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("company_id");

                    b.Property<int?>("Credit")
                        .HasColumnType("int")
                        .HasColumnName("credit");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("email");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("ntext")
                        .HasColumnName("fullname");

                    b.Property<string>("Gender")
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<double?>("Gpa")
                        .HasColumnType("float")
                        .HasColumnName("gpa");

                    b.Property<int>("MajorId")
                        .HasColumnType("int")
                        .HasColumnName("major_id");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCode")
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("student_code");

                    b.Property<int?>("Term")
                        .HasColumnType("int")
                        .HasColumnName("term");

                    b.Property<string>("WorkingStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("MajorId");

                    b.ToTable("tbl_student");
                });

            modelBuilder.Entity("Domain.CompanyAccount", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("CompanyAccounts")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.OjtReports", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("OjtReports")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_tbl_ojt_report_tbl_company")
                        .IsRequired();

                    b.HasOne("Domain.Student", "Student")
                        .WithMany("OjtReports")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_tbl_ojt_report_tbl_student")
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.RecruimentApply", b =>
                {
                    b.HasOne("Domain.RecruitmentInformation", "RecruimentInformation")
                        .WithMany("RecruimentApplies")
                        .HasForeignKey("RecruimentInformationId")
                        .HasConstraintName("FK_tbl_recruiment_apply_tbl_recruitment_information");

                    b.HasOne("Domain.Student", "Student")
                        .WithMany("RecruimentApplies")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_tbl_recruiment_apply_tbl_student");

                    b.Navigation("RecruimentInformation");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.RecruitmentInformation", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("RecruitmentInformations")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_tbl_recruitment_information_tbl_company");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("Students")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_tbl_student_tbl_company");

                    b.HasOne("Domain.Major", "Major")
                        .WithMany("Students")
                        .HasForeignKey("MajorId")
                        .HasConstraintName("FK_tbl_student_tbl_major")
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Navigation("CompanyAccounts");

                    b.Navigation("OjtReports");

                    b.Navigation("RecruitmentInformations");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.Major", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.RecruitmentInformation", b =>
                {
                    b.Navigation("RecruimentApplies");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Navigation("OjtReports");

                    b.Navigation("RecruimentApplies");
                });
#pragma warning restore 612, 618
        }
    }
}
