using System;
using System.Collections.Generic;
using ClienteEndereco.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteEndereco.Data;

public partial class PbsTesteContext : DbContext
{
    public PbsTesteContext()
    {
    }

    public PbsTesteContext(DbContextOptions<PbsTesteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Models.ClienteEndereco> ClienteEnderecos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PBS_TESTE;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLIENTE");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DatInclusao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DAT_INCLUSAO");
            entity.Property(e => e.DtNascimento)
                .HasColumnType("datetime")
                .HasColumnName("DT_NASCIMENTO");
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .HasColumnName("NOME");
            entity.Property(e => e.Status).HasColumnName("STATUS");
        });

        modelBuilder.Entity<Models.ClienteEndereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLIENTE_ENDERECO");

            entity.ToTable("CLIENTE_ENDERECOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Bairro)
                .HasMaxLength(60)
                .HasColumnName("BAIRRO");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .HasColumnName("CIDADE");
            entity.Property(e => e.DatInclusao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DAT_INCLUSAO");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(100)
                .HasColumnName("LOGRADOURO");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("UF");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClienteEnderecos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLIENTE_CLIENTE_ENDERECOS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
