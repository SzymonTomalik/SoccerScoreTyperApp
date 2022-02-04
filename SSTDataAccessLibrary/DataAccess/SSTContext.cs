using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSTDataAccessLibrary.Models;
using SSTDataAccessLibrary.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace SSTDataAccessLibrary.DataAccess
{
    public class SSTContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TyperConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        public SSTContext(DbContextOptions options) : base(options) { }
        public DbSet<Typer> Typers { get; set; }
        public DbSet<TyperGroup> TyperGroups { get; set; }
        public DbSet<TyperGroupAccount> TyperGroupAccounts { get; set; }
        public DbSet<SoccerMatch> SoccerMatches { get; set; }
        public DbSet<ScoreType> ScoreTypes { get; set; }

    }
}
