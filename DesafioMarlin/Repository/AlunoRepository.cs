using DesafioMarlin.Contexto;
using DesafioMarlin.Models;
using DesafioMarlin.Models.Dtos;
using DesafioMarlin.Models.Entities;
using DesafioMarlin.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Repository
{
    public class AlunoRepository : BaseRepository, IAlunoRepository
    {

        private readonly Context _context;

        public AlunoRepository(Context context) : base(context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<AlunoDto>> GetAlunosAsync()
        {
            return await _context.Alunos
                .Select(x => new AlunoDto { Id = x.Id, Nome = x.Nome, Cpf = x.Cpf, Email = x.Email}).ToListAsync();


        }

     
        public async Task<IEnumerable<AlunoTurmaDto>> GetAlunosTurmasAsync()
        {
            return await _context.AlunoTurma
                .Select(x => new AlunoTurmaDto { Id = x.Id ,AlunoId = x.AlunoId, TurmaId = x.TurmaId }).ToListAsync();

        }

        public async Task<AlunoTurma> GetAlunosTurmasIdAsync(int alunoId, int turmaId)
        {
            return await _context.AlunoTurma
                .Where(x => x.AlunoId == alunoId && x.TurmaId == turmaId)
                .FirstOrDefaultAsync();

        }

        public async Task<AlunoTurma> GetAlunosTurmasByIdAsync(int Id)
        {
            return await _context.AlunoTurma
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

        }

        public async Task<Aluno> GetAlunosByIdAsync(int id)
        {
            return await _context.Alunos.Include(x => x.Turmas).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Aluno> GetAlunosByCpfAsync(string cpf)
        {
            return await _context.Alunos.Where(x => x.Cpf == cpf).FirstOrDefaultAsync();
        }

        public async Task<Turma> GetTurmaByIdAsync(int id)
        {
            return await _context.Turmas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<AlunoTurma>> ContarAlunosNaTurma(int turmaId)
        {
            return await _context.AlunoTurma.Where(x => x.TurmaId == turmaId).ToListAsync();
        }

    }
}
