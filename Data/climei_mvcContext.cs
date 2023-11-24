using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClimeiMvc.Models;

namespace ClimeiMvc.Data
{
    public class climei_mvcContext : DbContext
    {
        public climei_mvcContext (DbContextOptions<climei_mvcContext> options)
            : base(options)
        {
        }

        public DbSet<ClimeiMvc.Models.Usuario> Usuario { get; set; } = default!;

        public DbSet<ClimeiMvc.Models.DadosUsuario>? DadosUsuario { get; set; }

        public DbSet<ClimeiMvc.Models.LogAgua>? LogAgua { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add your entity configurations and relationships here
            modelBuilder.Entity<DadosUsuario>()
                .HasOne(du => du.Usuario)
                .WithOne(u => u.DadosUsuario)
                .HasForeignKey<DadosUsuario>(e => e.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<LogAgua>()
                .HasOne(du => du.Usuario)
                .WithMany(u => u.LogAgua)
                .HasForeignKey(e => e.UsuarioId)
                .IsRequired();

        }

        public DbSet<ClimeiMvc.Models.NivelUmidade>? NivelUmidade { get; set; }

        public DbSet<ClimeiMvc.Models.NivelTemperatura>? NivelTemperatura { get; set; }

        public DbSet<ClimeiMvc.Models.LogBatimentoOxigenacao>? LogBatimentoOxigenacao { get; set; }

        public DbSet<ClimeiMvc.Models.LogTemperatura>? LogTemperatura { get; set; }

        public DbSet<ClimeiMvc.Models.LogUmidade>? LogUmidade { get; set; }

    }
}
