using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;
using System;
using DataLayer.AuxiliaryTypes;

namespace DataLayer.DbConfig
{
    public class DataContext : DbContext
    {
        public DbSet<WeekModel> Weeks { get; set; }
        public DbSet<BankrollModel> Bankrolls { get; set; }
        public DbSet<FundModel> Funds { get; set; }
        public DbSet<ExpenditureModel> Expenditures { get; set; }
        public DbSet<RevenueModel> Revenues { get; set; }
        public DbSet<FundConditionModel> FundConditions { get; set; }
        public DbSet<TransactionBetweenFundsModel> TransactionBetweenFunds { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=testdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FundModel>()
                        .Property(e => e.MoneySourceType)
                        .HasConversion(
                            v => v.ToString(),
                            v => (MoneySourceType)Enum.Parse(typeof(MoneySourceType), v));

            modelBuilder.Entity<FundModel>().HasData(
                new FundModel[]
                {
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "A1",
                        Name = "Фонд поставщиков ТМЦ",
                        PercentFromBanckroll = 80.0M,
                        MoneySourceType = MoneySourceType.Goods,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "A2",
                        Name = "Фонд поставщиков материалов",
                        PercentFromBanckroll = 15.0M,
                        MoneySourceType = MoneySourceType.Service,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "A3",
                        Name = "Фонд % с продаж для ОП",
                        PercentFromBanckroll = 3.0M,
                        MoneySourceType = MoneySourceType.ServiceAndGoods,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "A4",
                        Name = "Фонд внедрения 1C:ERP + ГОСТ РВ",
                        PercentFromBanckroll = 1.0M,
                        MoneySourceType = MoneySourceType.ServiceAndGoods,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B1",
                        Name = "Фонд дивидендов",
                        PercentFromBanckroll = 2.80M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B2",
                        Name = "Фонд налогов",
                        PercentFromBanckroll = 13.00M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B3",
                        Name = "Фонд аренды",
                        PercentFromBanckroll = 8.50M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B4",
                        Name = "Фонд оплаты труда",
                        PercentFromBanckroll = 48.50M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B5",
                        Name = "Фонд резервов",
                        PercentFromBanckroll = 3.50M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B6",
                        Name = "Фонд кредита",
                        PercentFromBanckroll = 18.0M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B7",
                        Name = "Фонд просроченной задолжности",
                        PercentFromBanckroll = 3.50M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B8",
                        Name = "Фонд средства производства и инструмент",
                        PercentFromBanckroll = 0.28M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "C1",
                        Name = "Фонд корпоративных расходов",
                        PercentFromBanckroll = 29.0M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "C2",
                        Name = "Фонд маркетинга",
                        PercentFromBanckroll = 29.0M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "C3",
                        Name = "Фонд жизнедеятельности",
                        PercentFromBanckroll = 42.0M,
                        MoneySourceType = MoneySourceType.Total,
                        IsAcitve = true
                    }
                });
        }
    }
}
