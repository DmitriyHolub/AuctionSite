using AuctionSite.EfStaff.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff
{
    public class AuctionSiteDbContext : DbContext
    {
        public AuctionSiteDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User>  Users { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<LotImage> LotImages { get; set; }
        public DbSet<TypeLot> TypeLots { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.LotsCreatedByUser)
                .WithOne(x => x.UserCreator);

            modelBuilder.Entity<Lot>()
               .HasMany(x => x.Observers)
               .WithMany(x => x.ObservedLots);

            modelBuilder.Entity<Lot>()
               .HasMany(x => x.UrlImages)
               .WithOne(x => x.Image);

            modelBuilder.Entity<Lot>()
              .HasOne(x => x.TypeOfLot)
              .WithMany(x => x.Lots);

            modelBuilder.Entity<User>()
              .HasMany(x => x.UsersBankCards)
              .WithOne(x => x.Owner);

            modelBuilder.Entity<User>()
                .HasMany(x => x.BuyerLot)
                .WithOne(x => x.LastBidUser);

            modelBuilder.Entity<User>()
                .HasMany(x => x.FavoriteTypesOfLots)
                .WithMany(x => x.UserFavoriteTypeOfLot);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
