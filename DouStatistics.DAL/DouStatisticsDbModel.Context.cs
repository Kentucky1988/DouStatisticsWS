﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DouStatistics.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DouStatisticsDbContext : DbContext
    {
        public DouStatisticsDbContext()
            : base("name=DouStatisticsDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<KeyWords> KeyWords { get; set; }
        public virtual DbSet<LogException> LogException { get; set; }
        public virtual DbSet<WorkService> WorkService { get; set; }
        public virtual DbSet<ResultsSearch> ResultsSearch { get; set; }
    }
}
