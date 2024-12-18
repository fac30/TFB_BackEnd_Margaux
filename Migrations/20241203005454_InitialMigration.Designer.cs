﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TFB_BackEnd_Margaux.Data;

#nullable disable

namespace TFB_BackEnd_Margaux.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241203005454_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DefaultName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ClothingItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ItemDesc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoLink")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("ClothingItems");
                });

            modelBuilder.Entity("OutfitItem", b =>
                {
                    b.Property<int>("OutfitId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("AddedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("OutfitId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("OutfitItems");
                });

            modelBuilder.Entity("TFB_BackEnd_Margaux.Models.Outfit", b =>
                {
                    b.Property<int>("OutfitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OutfitId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("OutfitName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OutfitId");

                    b.HasIndex("UserId");

                    b.ToTable("Outfits");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClothingItem", b =>
                {
                    b.HasOne("Category", "Category")
                        .WithMany("ClothingItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany("ClothingItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OutfitItem", b =>
                {
                    b.HasOne("ClothingItem", "ClothingItem")
                        .WithMany("OutfitItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFB_BackEnd_Margaux.Models.Outfit", "Outfit")
                        .WithMany("OutfitItems")
                        .HasForeignKey("OutfitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClothingItem");

                    b.Navigation("Outfit");
                });

            modelBuilder.Entity("TFB_BackEnd_Margaux.Models.Outfit", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany("Outfits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.Navigation("ClothingItems");
                });

            modelBuilder.Entity("ClothingItem", b =>
                {
                    b.Navigation("OutfitItems");
                });

            modelBuilder.Entity("TFB_BackEnd_Margaux.Models.Outfit", b =>
                {
                    b.Navigation("OutfitItems");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("ClothingItems");

                    b.Navigation("Outfits");
                });
#pragma warning restore 612, 618
        }
    }
}
