﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P2_AP1_20190266.DAL;

namespace P2_AP1_20190266.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("P2_AP1_20190266.Entidades.Proyecto", b =>
                {
                    b.Property<int>("Proyectoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("Proyectoid");

                    b.ToTable("Proyecto");
                });

            modelBuilder.Entity("P2_AP1_20190266.Entidades.TipoDeTareas", b =>
                {
                    b.Property<int>("Tipoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Requerimiento")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tiempo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipodeTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("Tipoid");

                    b.ToTable("TipoDeTarea");

                    b.HasData(
                        new
                        {
                            Tipoid = 1,
                            Requerimiento = " ",
                            Tiempo = 0,
                            TipodeTarea = "Analisis"
                        },
                        new
                        {
                            Tipoid = 2,
                            Requerimiento = "Hacer un diseno excelente",
                            Tiempo = 0,
                            TipodeTarea = "Diseno"
                        },
                        new
                        {
                            Tipoid = 3,
                            Requerimiento = "Programar todo el registro",
                            Tiempo = 0,
                            TipodeTarea = "Programacion"
                        },
                        new
                        {
                            Tipoid = 4,
                            Requerimiento = "Probar con mucho cuidado",
                            Tiempo = 0,
                            TipodeTarea = "Prueba"
                        });
                });

            modelBuilder.Entity("P2_AP1_20190266.Entidades.TipoDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Proyectoid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Requerimiento")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tiempo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipodeTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Proyectoid");

                    b.ToTable("TipoDetalle");
                });

            modelBuilder.Entity("P2_AP1_20190266.Entidades.TipoDetalle", b =>
                {
                    b.HasOne("P2_AP1_20190266.Entidades.Proyecto", null)
                        .WithMany("TipoDetalle")
                        .HasForeignKey("Proyectoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("P2_AP1_20190266.Entidades.Proyecto", b =>
                {
                    b.Navigation("TipoDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
