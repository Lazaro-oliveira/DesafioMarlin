using DesafioMarlin.Models;
using DesafioMarlin.Models.Dtos;
using DesafioMarlin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Repository.Interfaces
{
    public interface IAlunoRepository : IBaseRepository
    {
        Task<IEnumerable<AlunoDto>> GetAlunosAsync();

        Task<Aluno> GetAlunosByIdAsync(int id);

        Task<IEnumerable<AlunoTurmaDto>> GetAlunosTurmasAsync();

        Task<AlunoTurma> GetAlunosTurmasIdAsync(int alunoId, int turmaId);

        Task<AlunoTurma> GetAlunosTurmasByIdAsync(int id);

        Task<Aluno> GetAlunosByCpfAsync(string cpf);

        Task<Turma> GetTurmaByIdAsync(int id);

        Task<ICollection<AlunoTurma>> ContarAlunosNaTurma(int turmaId);



    }
}
