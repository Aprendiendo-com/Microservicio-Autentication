using Microservicio_Autentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Autentication.AccessData.Context
{
    public class GenericContex: DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }

        public GenericContex() {

        }

        public GenericContex(DbContextOptions<GenericContex> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=MicroAutentication;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(q => q.RolId);

                entity.Property(q => q.RolId).HasMaxLength(45).IsRequired();
            }
            );
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(q => q.UsuarioId);
                entity.Property(q => q.Nombre).HasMaxLength(45).IsRequired();
                entity.Property(q => q.Apellido).HasMaxLength(45).IsRequired();
                entity.Property(q => q.Email).HasMaxLength(45).IsRequired();
            }
            );

            modelBuilder.Entity<UsuarioRol>(entity =>
            {

                entity.HasKey(q => q.UsuarioRolId);

                entity.HasOne(q => q.Usuarios)
                .WithMany(q => q.UsuarioRolNavigator)
                .HasForeignKey(q => q.UsuarioId);

                entity.HasOne(q => q.Roles)
                .WithMany(q => q.UsuarioRolNavigator)
                .HasForeignKey(q => q.RolId);
            }
            );

        }
    }
}
