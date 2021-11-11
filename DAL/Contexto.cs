using Microsoft.EntityFrameworkCore;
using P2_AP1_20190266.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_20190266.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<TipoDeTareas> TipoDeTarea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DATA Source = DATA/User.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDeTareas>().HasData(new TipoDeTareas
            {

                Tipoid = 1,
                TipodeTarea = "Analisis",
                Requerimiento = " "
            });

            modelBuilder.Entity<TipoDeTareas>().HasData(new TipoDeTareas
            {
                Tipoid = 2,
                TipodeTarea = "Diseno",
                Requerimiento = "Hacer un diseno excelente"
            });

            modelBuilder.Entity<TipoDeTareas>().HasData(new TipoDeTareas
            {
                Tipoid = 3,
                TipodeTarea = "Programacion",
                Requerimiento = "Programar todo el registro"
            });

            modelBuilder.Entity<TipoDeTareas>().HasData(new TipoDeTareas
            {
                Tipoid = 4,
                TipodeTarea = "Prueba",
                Requerimiento = "Probar con mucho cuidado"
            });
        }
    }
}
