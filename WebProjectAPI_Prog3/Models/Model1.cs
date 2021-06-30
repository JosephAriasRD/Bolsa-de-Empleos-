using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebProjectAPI_Prog3.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=WepApiModel")
        {
        }

        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<CIUDAD> CIUDAD { get; set; }
        public virtual DbSet<PAIS> PAIS { get; set; }
        public virtual DbSet<POST> POST { get; set; }
        public virtual DbSet<TIPO_TRABAJO> TIPO_TRABAJO { get; set; }
        public virtual DbSet<USER_ADMIN> USER_ADMIN { get; set; }
        public virtual DbSet<USER_POSTER> USER_POSTER { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA>()
                .HasMany(e => e.POST)
                .WithRequired(e => e.CATEGORIA)
                .HasForeignKey(e => e.Nombre_Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CIUDAD>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<CIUDAD>()
                .HasMany(e => e.POST)
                .WithRequired(e => e.CIUDAD)
                .HasForeignKey(e => e.Nombre_Ciudad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CIUDAD>()
                .HasMany(e => e.USER_POSTER)
                .WithRequired(e => e.CIUDAD)
                .HasForeignKey(e => e.Nombre_Ciudad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAIS>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PAIS>()
                .HasMany(e => e.CIUDAD)
                .WithRequired(e => e.PAIS)
                .HasForeignKey(e => e.Nombre_Pais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAIS>()
                .HasMany(e => e.POST)
                .WithRequired(e => e.PAIS)
                .HasForeignKey(e => e.Nombre_Pais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAIS>()
                .HasMany(e => e.USER_POSTER)
                .WithRequired(e => e.PAIS)
                .HasForeignKey(e => e.Nombre_Pais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.Direccion_URL)
                .IsUnicode(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.Nombre_Posicion)
                .IsUnicode(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.Nombre_Calle)
                .IsUnicode(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_TRABAJO>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_TRABAJO>()
                .HasMany(e => e.POST)
                .WithRequired(e => e.TIPO_TRABAJO)
                .HasForeignKey(e => e.Nombre_Tipo_Trabajo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_ADMIN>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ADMIN>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ADMIN>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ADMIN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<USER_POSTER>()
                .Property(e => e.Nombre_Empresa)
                .IsUnicode(false);

            modelBuilder.Entity<USER_POSTER>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<USER_POSTER>()
                .Property(e => e.Contra)
                .IsUnicode(false);

            modelBuilder.Entity<USER_POSTER>()
                .Property(e => e.Nombre_Calle)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}
