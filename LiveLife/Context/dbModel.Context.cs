﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveLife.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LiveLifeEntities : DbContext
    {
        public LiveLifeEntities()
            : base("name=LiveLifeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CarrierMGA> CarrierMGAs { get; set; }
        public virtual DbSet<tblAdvisor> tblAdvisors { get; set; }
        public virtual DbSet<tblContract> tblContracts { get; set; }
    }
}
