﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace zerohungerv2.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class zerohungerv2Entities : DbContext
    {
        public zerohungerv2Entities()
            : base("name=zerohungerv2Entities7")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COLLECT_RQST> COLLECT_RQST { get; set; }
        public virtual DbSet<DISTRIBUTION_RCRD> DISTRIBUTION_RCRD { get; set; }
        public virtual DbSet<FOOD_ITEM> FOOD_ITEM { get; set; }
        public virtual DbSet<NGO_EMP> NGO_EMP { get; set; }
        public virtual DbSet<RESTAURANT> RESTAURANTs { get; set; }
    }
}
