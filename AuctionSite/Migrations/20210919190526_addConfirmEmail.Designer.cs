﻿// <auto-generated />
using System;
using AuctionSite.EfStaff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuctionSite.Migrations
{
    [DbContext(typeof(AuctionSiteDbContext))]
    [Migration("20210919190526_addConfirmEmail")]
    partial class addConfirmEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuctionSite.EfStaff.Models.BankCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.ExchangeRate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("TypeCurrency")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.Lot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BuyoutPrice")
                        .HasColumnType("float");

                    b.Property<bool>("CheckAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FinishBidding")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastBidUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LotName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MistakeAfterCheck")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartBidding")
                        .HasColumnType("datetime2");

                    b.Property<double>("StartPrice")
                        .HasColumnType("float");

                    b.Property<int>("StatusLot")
                        .HasColumnType("int");

                    b.Property<long?>("TypeOfLotId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserCreatorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LastBidUserId");

                    b.HasIndex("TypeOfLotId");

                    b.HasIndex("UserCreatorId");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.LotImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ImageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("LotImages");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.TypeLot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TypeOfLot")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TypeLots");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ConfirmEmail")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreferingCurrency")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfUSer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LotUser", b =>
                {
                    b.Property<long>("ObservedLotsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ObserversId")
                        .HasColumnType("bigint");

                    b.HasKey("ObservedLotsId", "ObserversId");

                    b.HasIndex("ObserversId");

                    b.ToTable("LotUser");
                });

            modelBuilder.Entity("TypeLotUser", b =>
                {
                    b.Property<long>("FavoriteTypesOfLotsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserFavoriteTypeOfLotId")
                        .HasColumnType("bigint");

                    b.HasKey("FavoriteTypesOfLotsId", "UserFavoriteTypeOfLotId");

                    b.HasIndex("UserFavoriteTypeOfLotId");

                    b.ToTable("TypeLotUser");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.BankCard", b =>
                {
                    b.HasOne("AuctionSite.EfStaff.Models.User", "Owner")
                        .WithMany("UsersBankCards")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.Lot", b =>
                {
                    b.HasOne("AuctionSite.EfStaff.Models.User", "LastBidUser")
                        .WithMany("BuyerLot")
                        .HasForeignKey("LastBidUserId");

                    b.HasOne("AuctionSite.EfStaff.Models.TypeLot", "TypeOfLot")
                        .WithMany("Lots")
                        .HasForeignKey("TypeOfLotId");

                    b.HasOne("AuctionSite.EfStaff.Models.User", "UserCreator")
                        .WithMany("LotsCreatedByUser")
                        .HasForeignKey("UserCreatorId");

                    b.Navigation("LastBidUser");

                    b.Navigation("TypeOfLot");

                    b.Navigation("UserCreator");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.LotImage", b =>
                {
                    b.HasOne("AuctionSite.EfStaff.Models.Lot", "Image")
                        .WithMany("UrlImages")
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("LotUser", b =>
                {
                    b.HasOne("AuctionSite.EfStaff.Models.Lot", null)
                        .WithMany()
                        .HasForeignKey("ObservedLotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionSite.EfStaff.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ObserversId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TypeLotUser", b =>
                {
                    b.HasOne("AuctionSite.EfStaff.Models.TypeLot", null)
                        .WithMany()
                        .HasForeignKey("FavoriteTypesOfLotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionSite.EfStaff.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserFavoriteTypeOfLotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.Lot", b =>
                {
                    b.Navigation("UrlImages");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.TypeLot", b =>
                {
                    b.Navigation("Lots");
                });

            modelBuilder.Entity("AuctionSite.EfStaff.Models.User", b =>
                {
                    b.Navigation("BuyerLot");

                    b.Navigation("LotsCreatedByUser");

                    b.Navigation("UsersBankCards");
                });
#pragma warning restore 612, 618
        }
    }
}
