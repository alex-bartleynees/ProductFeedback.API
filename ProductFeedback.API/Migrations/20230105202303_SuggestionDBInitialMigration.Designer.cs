﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductFeedback.API.DbContexts;

#nullable disable

namespace ProductFeedback.API.Migrations
{
    [DbContext(typeof(SuggestionContext))]
    [Migration("20230105202303_SuggestionDBInitialMigration")]
    partial class SuggestionDBInitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductFeedback.API.Entities.Suggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Upvotes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Suggestions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "enhancement",
                            Description = "Easier to search for solutions based on a specific stack.",
                            Status = "live",
                            Title = "Add tags for solutions okay",
                            Upvotes = 144
                        });
                });

            modelBuilder.Entity("ProductFeedback.API.Entities.SuggestionComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SuggestionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuggestionId");

                    b.HasIndex("UserId");

                    b.ToTable("SuggestionsComment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Awesome idea! Trying to find framework-specific projects within the hubs can be tedious",
                            SuggestionId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ProductFeedback.API.Entities.SuggestionCommentReply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ReplyingTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuggestionCommentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuggestionCommentId");

                    b.HasIndex("UserId");

                    b.ToTable("SuggestionsCommentReply");
                });

            modelBuilder.Entity("ProductFeedback.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "./assets/user-images/image-suzanne.jpg",
                            UserName = "Suzanne Chang"
                        });
                });

            modelBuilder.Entity("ProductFeedback.API.Entities.SuggestionComment", b =>
                {
                    b.HasOne("ProductFeedback.API.Entities.Suggestion", "Suggestion")
                        .WithMany("Comments")
                        .HasForeignKey("SuggestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductFeedback.API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suggestion");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductFeedback.API.Entities.SuggestionCommentReply", b =>
                {
                    b.HasOne("ProductFeedback.API.Entities.SuggestionComment", null)
                        .WithMany("Replies")
                        .HasForeignKey("SuggestionCommentId");

                    b.HasOne("ProductFeedback.API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductFeedback.API.Entities.Suggestion", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ProductFeedback.API.Entities.SuggestionComment", b =>
                {
                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}
