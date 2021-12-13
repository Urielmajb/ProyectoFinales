using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class DBEquipo : DbContext
    {
        public DBEquipo()
            : base("name=DBEquipo")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblDispositivo> tblDispositivo { get; set; }
        public virtual DbSet<tblEquipo> tblEquipo { get; set; }
        public virtual DbSet<tblPersonas> tblPersonas { get; set; }
        public virtual DbSet<tblReunion> tblReunion { get; set; }
        public virtual DbSet<tblRoles> tblRoles { get; set; }
        public virtual DbSet<tblTipoReunion> tblTipoReunion { get; set; }
        public virtual DbSet<tblUsuarios> tblUsuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<tblDispositivo>()
                .Property(e => e.Dispositivo)
                .IsUnicode(false);

            modelBuilder.Entity<tblEquipo>()
                .Property(e => e.NOM_EQUIPO)
                .IsUnicode(false);

            modelBuilder.Entity<tblEquipo>()
                .Property(e => e.CODIGO_ACTIVO)
                .IsUnicode(false);

            modelBuilder.Entity<tblEquipo>()
                .Property(e => e.ACTIVO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblEquipo>()
                .Property(e => e.DISPOSITIVO)
                .IsUnicode(false);

            modelBuilder.Entity<tblEquipo>()
                .HasMany(e => e.tblReunion)
                .WithOptional(e => e.tblEquipo)
                .HasForeignKey(e => e.Equipo_Id);

            modelBuilder.Entity<tblPersonas>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tblPersonas>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<tblPersonas>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<tblPersonas>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<tblPersonas>()
                .Property(e => e.ACTIVO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblPersonas>()
                .HasMany(e => e.tblReunion)
                .WithOptional(e => e.tblPersonas)
                .HasForeignKey(e => e.Persona_Id);

            modelBuilder.Entity<tblReunion>()
                .Property(e => e.NOM_REUNION)
                .IsUnicode(false);

            modelBuilder.Entity<tblReunion>()
                .Property(e => e.hora)
                .IsUnicode(false);

            modelBuilder.Entity<tblReunion>()
                .Property(e => e.TipoReunion)
                .IsUnicode(false);

            modelBuilder.Entity<tblTipoReunion>()
                .Property(e => e.TipoReunion)
                .IsUnicode(false);

            //modelBuilder.Entity<tblEquipo>()
            //    .HasMany(e => e.tblReunion)
            //    .WithRequired(e => e.tblEquipo)
            //    .HasForeignKey(e => e.Equipo_Id);

            //modelBuilder.Entity<tblPersonas>()
            //    .HasMany(e => e.tblReunion)
            //    .WithRequired(e => e.tblPersonas)
            //    .HasForeignKey(e => e.Persona_Id);
        }
    }
}
