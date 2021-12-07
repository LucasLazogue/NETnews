﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NETnews.Data;

namespace NETnews.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211207170604_user")]
    partial class user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("NETnews.Models.Comment", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("idNews")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id", "userId");

                    b.HasIndex("idNews");

                    b.ToTable("NewsComments");
                });

            modelBuilder.Entity("NETnews.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("journalistId")
                        .HasColumnType("int");

                    b.Property<string>("source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("journalistId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("NETnews.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("NETnews.Models.Journalist", b =>
                {
                    b.HasBaseType("NETnews.Models.Person");

                    b.HasDiscriminator().HasValue("Journalist");
                });

            modelBuilder.Entity("NETnews.Models.User", b =>
                {
                    b.HasBaseType("NETnews.Models.Person");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("NETnews.Models.Comment", b =>
                {
                    b.HasOne("NETnews.Models.User", "user")
                        .WithMany("comments")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NETnews.Models.News", "news")
                        .WithMany("comments")
                        .HasForeignKey("idNews")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("news");

                    b.Navigation("user");
                });

            modelBuilder.Entity("NETnews.Models.News", b =>
                {
                    b.HasOne("NETnews.Models.Journalist", "journalist")
                        .WithMany()
                        .HasForeignKey("journalistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("journalist");
                });

            modelBuilder.Entity("NETnews.Models.News", b =>
                {
                    b.Navigation("comments");
                });

            modelBuilder.Entity("NETnews.Models.User", b =>
                {
                    b.Navigation("comments");
                });
#pragma warning restore 612, 618
        }
    }
}