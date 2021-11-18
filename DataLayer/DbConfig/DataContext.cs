using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;
using System;

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
            modelBuilder.Entity<FundModel>().HasData(
                new FundModel[]
                {
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "A1",
                        Name = "Фонд поставщиков ТМЦ",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 80.0M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "A2",
                        Name = "Фонд поставщиков материалов",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 15.0M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "A3",
                        Name = "Фонд % с продаж для ОП",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 3.0M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "A4",
                        Name = "Фонд внедрения 1C:ERP + ГОСТ РВ",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 1.0M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B1",
                        Name = "Фонд дивидендов",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 2.80M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B2",
                        Name = "Фонд налогов",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 13.00M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B3",
                        Name = "Фонд аренды",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 8.50M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B4",
                        Name = "Фонд оплаты труда",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 48.50M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B5",
                        Name = "Фонд резервов",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 3.50M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B6",
                        Name = "Фонд кредита",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 18.0M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B7",
                        Name = "Фонд просроченной задолжности",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 3.50M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "B8",
                        Name = "Фонд средства производства и инструмент",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 0.28M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "C1",
                        Name = "Фонд корпоративных расходов",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 29.0M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "C2",
                        Name = "Фонд маркетинга",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 29.0M,
                        TotalSum = 0.0M
                    },
                    new FundModel {
                        Id = Convert.ToString(Guid.NewGuid()),
                        Key = "C3",
                        Name = "Фонд жизнедеятельности",
                        MonthForecast = 0.0M,
                        PercentFromBanckroll = 42.0M,
                        TotalSum = 0.0M
                    }
                });
        }
    }
}
