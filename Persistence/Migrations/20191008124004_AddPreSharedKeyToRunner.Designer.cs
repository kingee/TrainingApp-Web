﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20191008124004_AddPreSharedKeyToRunner")]
    partial class AddPreSharedKeyToRunner
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Coach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("Domain.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAdress");

                    b.HasKey("Id");

                    b.ToTable("MyProperty");
                });

            modelBuilder.Entity("Domain.Runner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CoachId");

                    b.Property<Guid?>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<string>("PreSharedCode");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("EmailId");

                    b.ToTable("Runners");
                });

            modelBuilder.Entity("Domain.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CoachId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateToDo");

                    b.Property<bool>("IsDone");

                    b.Property<Guid?>("RunnerId");

                    b.Property<Guid?>("TraningDetailsId");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("RunnerId");

                    b.HasIndex("TraningDetailsId");

                    b.ToTable("Traings");
                });

            modelBuilder.Entity("Domain.TraningDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Details");

                    b.HasKey("Id");

                    b.ToTable("TraningDetails");
                });

            modelBuilder.Entity("Domain.Coach", b =>
                {
                    b.HasOne("Domain.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId");
                });

            modelBuilder.Entity("Domain.Runner", b =>
                {
                    b.HasOne("Domain.Coach", "Coach")
                        .WithMany("Runners")
                        .HasForeignKey("CoachId");

                    b.HasOne("Domain.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId");
                });

            modelBuilder.Entity("Domain.Training", b =>
                {
                    b.HasOne("Domain.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId");

                    b.HasOne("Domain.Runner", "Runner")
                        .WithMany("Trainings")
                        .HasForeignKey("RunnerId");

                    b.HasOne("Domain.TraningDetails", "TraningDetails")
                        .WithMany()
                        .HasForeignKey("TraningDetailsId");
                });
#pragma warning restore 612, 618
        }
    }
}
