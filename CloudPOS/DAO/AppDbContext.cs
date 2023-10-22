﻿using CloudPOS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudPOS.DAO
{
    public class AppDbContext : IdentityDbContext<IdentityUser,IdentityRole,string>
    {
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
     //define the Entities for database DB Sets
     public DbSet<CategoryEntity> Categories { get; set; }
     public DbSet<BrandEntity> Brands { get; set; }
     public DbSet<ItemEntity> Items { get; set; }
     public DbSet<StockInComeEntity> StockInComes { get; set; }
     public DbSet<StockBalanceEntity> StockBalances { get; set; }
    public DbSet<SaleEntity> Sales { get; set; }
    public DbSet<SaleDetailEntity> SaleDetails { get; set; }
    }
}
