using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI01.Repository.Mappings
{
    //Classe de mapeamento para a entidade Funcionario (ORM)
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //nome da tabela no banco de dados
            builder.ToTable("FUNCIONARIO");

            //chave primária da tabela
            //HasKey -> Primary key
            builder.HasKey(f => f.IdFuncionario);

            //mapear os campos da tabela
            builder.Property(f => f.IdFuncionario)
                .HasColumnName("IDFUNCIONARIO");

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
               .HasColumnName("DATAADMISSAO")
               .HasColumnType("date") //tipo no banco de dados
               .IsRequired();

            builder.Property(f => f.DataNascimento)
                .HasColumnName("DATANASCIMENTO")
                .HasColumnType("date") //tipo no banco de dados
                .IsRequired();

            builder.Property(f => f.IdEmpresa)
                .HasColumnName("IDEMPRESA")
                .IsRequired();

            //mapeamento de campos unicos (UNIQUE)
            builder.HasIndex(f => f.Cpf)
                .IsUnique();

            //mapeamento das chaves estrangeiras
            //Foreign Key (OneToMany)
            builder.HasOne(f => f.Empresa) //Funcionario PERTENCE A 1 Empresa
                .WithMany(e => e.Funcionarios) //Empresa TEM MUITOS Funcionarios
                .HasForeignKey(f => f.IdEmpresa); //campo chave estrangeira
        }
    }
}
