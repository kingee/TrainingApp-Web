﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Coach", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<string>("PreSharedKey");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasAlternateKey("Login");

                    b.ToTable("Coaches","Core");
                });

            modelBuilder.Entity("Domain.Runner", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("RunnerId");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("RunnerId");

                    b.ToTable("Runners","Core");
                });

            modelBuilder.Entity("Domain.Training", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateToDo");

                    b.Property<bool>("IsDone")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<Guid?>("RunnerId");

                    b.Property<Guid?>("TraningDetailsId");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("RunnerId");

                    b.HasIndex("TraningDetailsId");

                    b.ToTable("Trainings","Core");
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
                    b.OwnsOne("Domain.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CoachId");

                            b1.Property<string>("EmailAdress")
                                .IsRequired()
                                .HasColumnName("Email");

                            b1.HasKey("CoachId");

                            b1.ToTable("Coaches","Core");

                            b1.HasOne("Domain.Coach")
                                .WithOne("Email")
                                .HasForeignKey("Domain.Email", "CoachId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Domain.Runner", b =>
                {
                    b.HasOne("Domain.Coach", "Coach")
                        .WithMany("Runners")
                        .HasForeignKey("RunnerId");

                    b.OwnsOne("Domain.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("RunnerId");

                            b1.Property<string>("EmailAdress")
                                .IsRequired()
                                .HasColumnName("Email");

                            b1.HasKey("RunnerId");

                            b1.ToTable("Runners","Core");

                            b1.HasOne("Domain.Runner")
                                .WithOne("Email")
                                .HasForeignKey("Domain.Email", "RunnerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Domain.Training", b =>
                {
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
