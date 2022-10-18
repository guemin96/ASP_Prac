﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Note.DAL.DataContext;

namespace Note.DAL.Migrations
{
    [DbContext(typeof(NoteDbContext))]
    [Migration("20221018064658_Notice1")]
    partial class Notice1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Note.Model.Notice", b =>
                {
                    b.Property<int>("NoticeNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NoticeContents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoticeTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NoticeWriteDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NoticeNo");

                    b.ToTable("notices");
                });
#pragma warning restore 612, 618
        }
    }
}