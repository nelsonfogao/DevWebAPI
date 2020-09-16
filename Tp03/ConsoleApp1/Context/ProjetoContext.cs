using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.Extensions.Logging;
using Repository.Mapping;

namespace Repository.Context
{
    public class ProjetoContext : DbContext
    {
        public DbSet<Amigo> Amigo { get; set; }

        public static readonly ILoggerFactory _loggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public ProjetoContext (DbContextOptions<ProjetoContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AmigoMap());

            base.OnModelCreating(modelBuilder);
        }


    }
}
