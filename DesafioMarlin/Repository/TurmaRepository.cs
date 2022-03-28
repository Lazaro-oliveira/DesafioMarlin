using DesafioMarlin.Contexto;
using DesafioMarlin.Models;
using DesafioMarlin.Models.Entities;
using DesafioMarlin.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Repository
{
    public class TurmaRepository : BaseRepository, ITurmaRepository
    {

        private readonly Context _context;

        public TurmaRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Turma>> GetTurmasAsync()
        {
            return await _context.Turmas.Include(x => x.Alunos).ToListAsync();
            
        }

        public async Task<IEnumerable<Turma>> GetTurmasAlunosAsync()
        {
            return await _context.Turmas.Include(x => x.Alunos).ToListAsync();
        }

        public async Task<Turma> GetTurmasByIdAsync(int id)
        {
            return await _context.Turmas.Include(x => x.Alunos).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<AlunoTurma> GetAlunosTurmasByIdAsync(int TurmaId)
        {
            return await _context.AlunoTurma
                .Where(x => x.TurmaId == TurmaId)
                .FirstOrDefaultAsync();

        }
    }
}
