﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.yrtech.InventoryDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Inventory : DbContext
    {
        public Inventory()
            : base("name=Inventory")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<AnswerRecheck> AnswerRecheck { get; set; }
        public virtual DbSet<AnswerRecheckSet> AnswerRecheckSet { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<CarType> CarType { get; set; }
        public virtual DbSet<HiddenCode> HiddenCode { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<RoleType> RoleType { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<ShopStatus> ShopStatus { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserInfoBrand> UserInfoBrand { get; set; }
    }
}
