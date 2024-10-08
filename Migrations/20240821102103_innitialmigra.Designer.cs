﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student__management__system.Data;

#nullable disable

namespace Student__management__system.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    [Migration("20240821102103_innitialmigra")]
    partial class innitialmigra
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Student__management__system.Models.ClassStream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClassStream");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Science Stream",
                            Name = "Science"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Arts Stream",
                            Name = "Arts"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Commerce Stream",
                            Name = "Commerce"
                        });
                });

            modelBuilder.Entity("Student__management__system.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Age = 16,
                            FirstName = "John ",
                            Id = 1,
                            LastName = "Doe"
                        },
                        new
                        {
                            StudentId = 2,
                            Age = 17,
                            FirstName = "Jane Doe",
                            Id = 2,
                            LastName = "Doe"
                        },
                        new
                        {
                            StudentId = 3,
                            Age = 16,
                            FirstName = "Jim ",
                            Id = 3,
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("Student__management__system.Models.Student", b =>
                {
                    b.HasOne("Student__management__system.Models.ClassStream", "ClassStream")
                        .WithMany("Students")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassStream");
                });

            modelBuilder.Entity("Student__management__system.Models.ClassStream", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
