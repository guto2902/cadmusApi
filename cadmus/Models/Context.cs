using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace cadmus.Models
{
    public partial class CadmusContext : DbContext
    {
        public CadmusContext(DbContextOptions<CadmusContext> options) : base(options)
        {
        }

        public CadmusContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            string ConnectioString = configuration["ConnectioString"];


            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectioString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => new { e.Numero })
                    .HasName("PK_Pedido");
            });


            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(c => c.Email).IsUnique();
            });
        }
        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Produto> Produtos { get; set; }

        public virtual DbSet<Pedido> Pedidos { get; set; }

        public virtual DbSet<PedidoItens> PedidoItens { get; set; }
    }
}
