using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestionTareas.Data.Entity;

public partial class ControlTareasContext : DbContext
{
    public ControlTareasContext()
    {
    }

    public ControlTareasContext(DbContextOptions<ControlTareasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignarTareaUsuario> AsignarTareaUsuarios { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<EstadoTarea> EstadoTareas { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=.;Database=ControlTareas;Trusted_Connection=True;TrustServerCertificate=True;");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        var connectionString = configuration.GetConnectionString("MiDB");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignarTareaUsuario>(entity =>
        {
            entity.HasKey(e => e.IdAsignarTareaUsuario);

            entity.ToTable("ASIGNAR_TAREA_USUARIO");

            entity.Property(e => e.IdAsignarTareaUsuario).HasColumnName("ID_ASIGNAR_TAREA_USUARIO");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACTIVO");
            entity.Property(e => e.EstadoTarea)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ESTADO_TAREA");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaMaxEntrega)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MAX_ENTREGA");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.IdTarea).HasColumnName("ID_TAREA");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(50)
                .HasColumnName("ID_USUARIO");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACTIVO");
            entity.Property(e => e.CodCategoria)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CATEGORIA");
            entity.Property(e => e.DescCategoria)
                .HasMaxLength(300)
                .HasColumnName("DESC_CATEGORIA");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_CATEGORIA");
        });

        modelBuilder.Entity<EstadoTarea>(entity =>
        {
            entity.HasKey(e => e.IdEstadoTarea);

            entity.ToTable("ESTADO_TAREA");

            entity.Property(e => e.IdEstadoTarea)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_ESTADO_TAREA");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACTIVO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.NombreEstadoTarea)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_ESTADO_TAREA");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea);

            entity.ToTable("TAREA");

            entity.Property(e => e.IdTarea).HasColumnName("ID_TAREA");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACTIVO");
            entity.Property(e => e.CodTarea)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_TAREA");
            entity.Property(e => e.DescTarea)
                .HasMaxLength(300)
                .HasColumnName("DESC_TAREA");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.NombreTarea)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_TAREA");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TAREA_CATEGORIA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario)
                .HasMaxLength(50)
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACTIVO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_USUARIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
