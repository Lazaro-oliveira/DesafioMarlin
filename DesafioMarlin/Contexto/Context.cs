using DesafioMarlin.Models;
using DesafioMarlin.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Contexto
{
    public class Context : DbContext
    {
        
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<AlunoTurma> AlunoTurma { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8T57EGA\\SQLEXPRESS;Database=DesafioMarlin;Trusted_Connection=True;USER ID =DESKTOP-8T57EGA\\Lazar");
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Aluno>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            builder.Entity<Aluno>(entity => {
                entity.HasIndex(e => e.Cpf).IsUnique();
            });

            builder.Entity<AlunoTurma>(entity => {
                entity.HasIndex(e => e.Id).IsUnique();
            });

            builder.Entity<Aluno>(entity =>
            {
                entity.HasMany(x => x.Turmas)
               .WithMany(x => x.Alunos)
               .UsingEntity<AlunoTurma>(
                   x => x.HasOne(p => p.Turmas).WithMany().HasForeignKey(x => x.TurmaId),
                   x => x.HasOne(p => p.Alunos).WithMany().HasForeignKey(x => x.AlunoId),
                   x =>
                   {
                       x.ToTable("AlunoTurma");

                       x.HasKey(p => new { p.TurmaId, p.AlunoId });

                       x.Property(p => p.TurmaId).HasColumnName("id_turma").IsRequired();
                       x.Property(p => p.AlunoId).HasColumnName("id_aluno").IsRequired();
                   }
               ); ;
            });

            builder.Entity<Turma>(entity =>
            {
                entity.HasMany(x => x.Alunos)
               .WithMany(x => x.Turmas)
               .UsingEntity<AlunoTurma>(
                   x => x.HasOne(p => p.Alunos).WithMany().HasForeignKey(x => x.AlunoId),
                   x => x.HasOne(p => p.Turmas).WithMany().HasForeignKey(x => x.TurmaId),
                   x =>
                   {
                       x.ToTable("AlunoTurma");

                       x.HasKey(p => new { p.TurmaId, p.AlunoId });

                       x.Property(p => p.TurmaId).HasColumnName("id_turma").IsRequired();
                       x.Property(p => p.AlunoId).HasColumnName("id_aluno").IsRequired();
                   }
               ); ;
            });

        }
    }
}
