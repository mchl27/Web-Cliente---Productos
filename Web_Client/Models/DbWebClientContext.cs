using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_Client.Models;

public partial class DbWebClientContext : DbContext
{
    public DbWebClientContext()
    {
    }

    public DbWebClientContext(DbContextOptions<DbWebClientContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=Michael\\SQLEXPRESS;Database=DB_web_client;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__1D8EFF0184CD94A9");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Empresa).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.Proveedor).HasMaxLength(255);
            entity.Property(e => e.Referencia).HasMaxLength(100);
            entity.Property(e => e.UltimoIngreso)
                .HasColumnType("datetime")
                .HasColumnName("Ultimo_ingreso");
            entity.Property(e => e.Unidad).HasMaxLength(50);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2D95A89411514EE3");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("Id_rol");
            entity.Property(e => e.Nombre).HasMaxLength(150);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__EF59F7625E0F55EC");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Contraseña).HasMaxLength(20);
            entity.Property(e => e.Creacion).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Estado).HasMaxLength(30);
            entity.Property(e => e.IdRol).HasColumnName("Id_rol");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__Id_rol__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
