﻿// <auto-generated />
using DataApiDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataApiDLL.Migrations
{
    [DbContext(typeof(JobContext))]
    [Migration("20190505151659_InitialCreate9")]
    partial class InitialCreate9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("DataApiDAL.Models.JobVacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Title")
                        .IsConcurrencyToken();

                    b.Property<string>("VacancyUrl");

                    b.HasKey("Id");

                    b.ToTable("JobVacancies");
                });
#pragma warning restore 612, 618
        }
    }
}
