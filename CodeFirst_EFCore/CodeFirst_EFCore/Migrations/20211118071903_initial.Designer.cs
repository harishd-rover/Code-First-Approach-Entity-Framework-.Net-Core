﻿// <auto-generated />
using CodeFirst_EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirst_EFCore.Migrations
{
    [DbContext(typeof(MyBookDBContext))]
    [Migration("20211118071903_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeFirst_EFCore.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("AuthName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AuthorName");

                    b.Property<string>("BookName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("AuthorID");

                    b.ToTable("Auth");
                });

            modelBuilder.Entity("CodeFirst_EFCore.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookPrice")
                        .HasColumnType("int");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
