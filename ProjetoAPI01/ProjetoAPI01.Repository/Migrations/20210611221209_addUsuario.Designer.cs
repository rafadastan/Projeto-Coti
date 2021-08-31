﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoAPI01.Repository.Contexts;

namespace ProjetoAPI01.Repository.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20210611221209_addUsuario")]
    partial class addUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoAPI01.Domain.Entities.Empresa", b =>
                {
                    b.Property<Guid>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDEMPRESA")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnName("CNPJ")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("NOMEFANTASIA")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnName("RAZAOSOCIAL")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdEmpresa");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("EMPRESA");
                });

            modelBuilder.Entity("ProjetoAPI01.Domain.Entities.Funcionario", b =>
                {
                    b.Property<Guid>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDFUNCIONARIO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnName("DATAADMISSAO")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DATANASCIMENTO")
                        .HasColumnType("date");

                    b.Property<Guid>("IdEmpresa")
                        .HasColumnName("IDEMPRESA")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnName("MATRICULA")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("IdFuncionario");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("IdEmpresa");

                    b.ToTable("FUNCIONARIO");
                });

            modelBuilder.Entity("ProjetoAPI01.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDUSUARIO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DATACADASTRO")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("SENHA")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("ProjetoAPI01.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("ProjetoAPI01.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
