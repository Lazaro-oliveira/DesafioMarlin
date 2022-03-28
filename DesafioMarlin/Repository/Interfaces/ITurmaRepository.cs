using DesafioMarlin.Models;
using DesafioMarlin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Repository.Interfaces
{
    public interface ITurmaRepository : IBaseRepository
    {
        Task<IEnumerable<Turma>> GetTurmasAsync();

        Task<IEnumerable<Turma>> GetTurmasAlunosAsync();

        Task<Turma> GetTurmasByIdAsync(int id);

        Task<AlunoTurma> GetAlunosTurmasByIdAsync(int TurmaId);
    }
}
