﻿// <auto-generated />
using Boardgames.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Boardgames.Migrations
{
    [DbContext(typeof(BoardgamesContext))]
    partial class BoardgamesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Boardgames.Data.Models.Boardgame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryType")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Mechanics")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("YearPublished")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Boardgames");
                });

            modelBuilder.Entity("Boardgames.Data.Models.BoardgameSeller", b =>
                {
                    b.Property<int>("BoardgameId")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("BoardgameId", "SellerId");

                    b.HasIndex("SellerId");

                    b.ToTable("BoardgamesSellers");
                });

            modelBuilder.Entity("Boardgames.Data.Models.Creator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("NVARCHAR(7)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("NVARCHAR(7)");

                    b.HasKey("Id");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("Boardgames.Data.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR(1000)");

                    b.HasKey("Id");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("Boardgames.Data.Models.Boardgame", b =>
                {
                    b.HasOne("Boardgames.Data.Models.Creator", "Creator")
                        .WithMany("Boardgames")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Boardgames.Data.Models.BoardgameSeller", b =>
                {
                    b.HasOne("Boardgames.Data.Models.Boardgame", "Boardgame")
                        .WithMany("BoardgamesSellers")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Boardgames.Data.Models.Seller", "Seller")
                        .WithMany("BoardgamesSellers")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boardgame");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Boardgames.Data.Models.Boardgame", b =>
                {
                    b.Navigation("BoardgamesSellers");
                });

            modelBuilder.Entity("Boardgames.Data.Models.Creator", b =>
                {
                    b.Navigation("Boardgames");
                });

            modelBuilder.Entity("Boardgames.Data.Models.Seller", b =>
                {
                    b.Navigation("BoardgamesSellers");
                });
#pragma warning restore 612, 618
        }
    }
}
