﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task2.Models;

#nullable disable

namespace task2.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20240212121401_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("task2.Models.department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MGRssn")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("startdate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("MGRssn")
                        .IsUnique()
                        .HasFilter("[MGRssn] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("task2.Models.dependant", b =>
                {
                    b.Property<int>("essn")
                        .HasColumnType("int");

                    b.Property<string>("dependant_name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("bdate")
                        .HasColumnType("date");

                    b.Property<string>("sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("essn", "dependant_name");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Dependants");
                });

            modelBuilder.Entity("task2.Models.employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("bdate")
                        .HasColumnType("date");

                    b.Property<int?>("dno")
                        .HasColumnType("int");

                    b.Property<string>("fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("salary")
                        .HasColumnType("money");

                    b.Property<int?>("superssn")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("dno");

                    b.HasIndex("superssn");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("task2.Models.project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dnum")
                        .HasColumnType("int");

                    b.Property<string>("plocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("dnum");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("task2.Models.works_for", b =>
                {
                    b.Property<int>("essn")
                        .HasColumnType("int");

                    b.Property<int>("pnum")
                        .HasColumnType("int");

                    b.Property<int>("houres")
                        .HasColumnType("int");

                    b.HasKey("essn", "pnum");

                    b.HasIndex("pnum");

                    b.ToTable("works_Fors");
                });

            modelBuilder.Entity("task2.Models.department", b =>
                {
                    b.HasOne("task2.Models.employee", "managr")
                        .WithOne("manageDepartment")
                        .HasForeignKey("task2.Models.department", "MGRssn");

                    b.Navigation("managr");
                });

            modelBuilder.Entity("task2.Models.dependant", b =>
                {
                    b.HasOne("task2.Models.employee", "Employee")
                        .WithMany("Dependants")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("task2.Models.employee", b =>
                {
                    b.HasOne("task2.Models.department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("dno");

                    b.HasOne("task2.Models.employee", "manager")
                        .WithMany("group")
                        .HasForeignKey("superssn");

                    b.Navigation("Department");

                    b.Navigation("manager");
                });

            modelBuilder.Entity("task2.Models.project", b =>
                {
                    b.HasOne("task2.Models.department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("dnum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("task2.Models.works_for", b =>
                {
                    b.HasOne("task2.Models.employee", "Employee")
                        .WithMany("Works_Fors")
                        .HasForeignKey("essn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task2.Models.project", "Project")
                        .WithMany("Works_Fors")
                        .HasForeignKey("pnum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("task2.Models.department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("task2.Models.employee", b =>
                {
                    b.Navigation("Dependants");

                    b.Navigation("Works_Fors");

                    b.Navigation("group");

                    b.Navigation("manageDepartment")
                        .IsRequired();
                });

            modelBuilder.Entity("task2.Models.project", b =>
                {
                    b.Navigation("Works_Fors");
                });
#pragma warning restore 612, 618
        }
    }
}
