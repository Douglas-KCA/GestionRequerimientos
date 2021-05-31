using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GestionRequerimientos.Models
{
    public partial class RequerimientosContext : DbContext
    {
        public RequerimientosContext()
            : base("name=RequerimientosContext")
        {
        }

        public virtual DbSet<ACTIVIDAD> ACTIVIDAD { get; set; }
        public virtual DbSet<ESTADO> ESTADO { get; set; }
        public virtual DbSet<PERSONA> PERSONA { get; set; }
        public virtual DbSet<PROYECTO> PROYECTO { get; set; }
        public virtual DbSet<REQUERIMIENTO> REQUERIMIENTO { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<TIPO_REQUERIMIENTO> TIPO_REQUERIMIENTO { get; set; }
        public virtual DbSet<USUARIOS> USUARIOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.id_actividad)
                .HasPrecision(10, 0);

            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.id_requerimiento)
                .HasPrecision(10, 0);

            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.id_proyecto)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.tiempo)
                .HasPrecision(10, 0);

            modelBuilder.Entity<ACTIVIDAD>()
                .Property(e => e.porcentaje)
                .HasPrecision(10, 0);

            modelBuilder.Entity<ESTADO>()
                .Property(e => e.nom_estado)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO>()
                .Property(e => e.id_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO>()
                .Property(e => e.estado1)
                .HasPrecision(1, 0);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.dpi)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.id_proyecto)
                .IsUnicode(false);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.tiempo)
                .HasPrecision(10, 0);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.porcentaje)
                .IsUnicode(false);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.costo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.nom_estado)
                .IsUnicode(false);

            modelBuilder.Entity<PROYECTO>()
                .HasMany(e => e.REQUERIMIENTO)
                .WithRequired(e => e.PROYECTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REQUERIMIENTO>()
                .Property(e => e.id_requerimiento)
                .HasPrecision(10, 0);

            modelBuilder.Entity<REQUERIMIENTO>()
                .Property(e => e.id_proyecto)
                .IsUnicode(false);

            modelBuilder.Entity<REQUERIMIENTO>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<REQUERIMIENTO>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<REQUERIMIENTO>()
                .Property(e => e.tiempo)
                .HasPrecision(10, 0);

            modelBuilder.Entity<REQUERIMIENTO>()
                .Property(e => e.porcentaje)
                .IsUnicode(false);

            modelBuilder.Entity<REQUERIMIENTO>()
                .Property(e => e.costo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<REQUERIMIENTO>()
                .Property(e => e.nom_estado)
                .IsUnicode(false);

            modelBuilder.Entity<REQUERIMIENTO>()
                .Property(e => e.nom_req)
                .IsUnicode(false);

            modelBuilder.Entity<REQUERIMIENTO>()
                .HasMany(e => e.ACTIVIDAD)
                .WithRequired(e => e.REQUERIMIENTO)
                .HasForeignKey(e => new { e.id_requerimiento, e.id_proyecto })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.rol1)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.id_rol)
                .HasPrecision(10, 0);

            modelBuilder.Entity<ROL>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.estado)
                .HasPrecision(1, 0);

            modelBuilder.Entity<ROL>()
                .HasMany(e => e.USUARIOS)
                .WithOptional(e => e.ROL1)
                .HasForeignKey(e => e.rol);

            modelBuilder.Entity<TIPO_REQUERIMIENTO>()
                .Property(e => e.nom_req)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_REQUERIMIENTO>()
                .Property(e => e.id_tiporequerimiento)
                .HasPrecision(10, 0);

            modelBuilder.Entity<TIPO_REQUERIMIENTO>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_REQUERIMIENTO>()
                .Property(e => e.estado)
                .HasPrecision(1, 0);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.id_usuario)
                .HasPrecision(10, 0);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.dpi)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.rol)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .HasMany(e => e.ACTIVIDAD)
                .WithRequired(e => e.USUARIOS)
                .WillCascadeOnDelete(false);
        }
    }
}
