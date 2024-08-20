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
    [Migration("20240820080858_UpdatedStreamModel")]
    partial class UpdatedStreamModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Student__management__system.Models.Streams", b =>
                {
                    b.Property<int>("StreamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StreamId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StreamId");

                    b.ToTable("Streams");
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

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreamId")
                        .HasColumnType("int");

                    b.Property<int>("StreamsStreamId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("StreamsStreamId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Student__management__system.Models.Student", b =>
                {
                    b.HasOne("Student__management__system.Models.Streams", "Streams")
                        .WithMany("Students")
                        .HasForeignKey("StreamsStreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Streams");
                });

            modelBuilder.Entity("Student__management__system.Models.Streams", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
