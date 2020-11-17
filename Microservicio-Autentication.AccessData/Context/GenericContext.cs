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
            optionsBuilder.UseSqlServer("Server =.\\SQLEXPRESS; Database = MicroAutenticacion; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(q => q.RolId);

                entity.Property(q => q.RolId).HasMaxLength(45).IsRequired();

                entity.HasData( new Rol { RolId = 1, TipoRol = "Profesor"},
                                new Rol { RolId = 2, TipoRol = "Estudiante"}
                );
            }
            );
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(q => q.UsuarioId);
                entity.Property(q => q.Nombre).HasMaxLength(45).IsRequired();
                entity.Property(q => q.Apellido).HasMaxLength(45).IsRequired();
                entity.Property(q => q.Email).HasMaxLength(45).IsRequired();
                entity.Property(q => q.Contraseña).HasMaxLength(250).IsRequired();

                entity.HasData(new Usuario { Apellido = "Olivera", Nombre = "Lucas", Email = "lolivera.unaj@gmail.com", Contraseña = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", UsuarioId = 20 },
                                new Usuario { Apellido = "Conde", Nombre = "Sergio", Email = "sergiounaj@gmail.com", Contraseña = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", UsuarioId = 21 },
                                new Usuario { Apellido = "Jorge", Nombre = "Octavio", Email = "octaviojorge37@gmail.com", Contraseña = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", UsuarioId = 22 },
                                new Usuario { Apellido = "Amet", Nombre = "Leonardo", Email = "leonardoAmet@gmail.com", Contraseña = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", UsuarioId = 23 },
                                new Usuario { Apellido = "Osio", Nombre = "Jorge", Email = "jorgeosio@gmail.com", Contraseña = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", UsuarioId = 24 },
                                new Usuario { Apellido = "Rosa", Nombre = "Maria", Email = "mariarosa@gmail.com", Contraseña = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", UsuarioId = 25 });
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {

                entity.HasKey(q => q.UsuarioRolId);

                entity.HasOne(q => q.Usuarios)
                .WithMany(q => q.UsuarioRolNavigator)
                .HasForeignKey(q => q.UsuarioId);

                entity.HasOne(q => q.Roles)
                .WithMany(q => q.UsuarioRolNavigator)
                .HasForeignKey(q => q.RolId);

                entity.HasData(new UsuarioRol { UsuarioId = 20, RolId = 1, UsuarioRolId = 20 },
                                new UsuarioRol { UsuarioId = 21, RolId = 1, UsuarioRolId = 21 },
                                new UsuarioRol { UsuarioId = 22, RolId = 1, UsuarioRolId = 22 },
                                new UsuarioRol { UsuarioId = 23, RolId = 1, UsuarioRolId = 23 },
                                new UsuarioRol { UsuarioId = 24, RolId = 1, UsuarioRolId = 24 },
                                new UsuarioRol { UsuarioId = 25, RolId = 1, UsuarioRolId = 25 });
            }
            );

        }
    }
}
