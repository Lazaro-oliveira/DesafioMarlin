using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioMarlin.Models;
using DesafioMarlin.Repository.Interfaces;
using DesafioMarlin.Models.Dtos;
using AutoMapper;
using DesafioMarlin.Models.Entities;

namespace DesafioMarlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepository _repository;
        //private readonly ITurmaRepository _repositoryTurma;
        private readonly IMapper _mapper;

        public AlunosController(IAlunoRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
           // _repositoryTurma = repositoryTurma;
        }

       
        
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var alunos = await _repository.GetAlunosAsync();
            return alunos.Any()
                ? Ok(alunos)
                : BadRequest("Alunos não encotrados");
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var aluno = await _repository.GetAlunosByIdAsync(id);
            return aluno != null
                ? Ok(aluno)
                : BadRequest("Aluno não encotrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlunoAdicionarDto aluno)
        {
            if (aluno == null) return BadRequest("Dados invalidos");

            var alunoInserirDto = new AlunoInserirDto
            {
                Nome = aluno.Nome,
                Email = aluno.Email,
                Cpf = aluno.Cpf
            };
            
            var alunoAdicionar = _mapper.Map<Aluno>(alunoInserirDto);


            _repository.Add(alunoAdicionar);

            var testarIdTurma = await _repository.GetTurmaByIdAsync(aluno.TurmaId);

            if(testarIdTurma == null) return BadRequest("Id de turma não existe");

            var ContarAlunosNaTurma = await _repository.ContarAlunosNaTurma(aluno.TurmaId);

            if (ContarAlunosNaTurma.Count >= 5) return BadRequest("Turma cheia"); 

            await _repository.SaveChangesAsync();

            var BuscarAlunoSalvo = await _repository.GetAlunosByCpfAsync(aluno.Cpf);

            var matriculaAdicionar = new AlunoTurma
            {
                AlunoId = BuscarAlunoSalvo.Id,
                TurmaId = aluno.TurmaId
            };

            _repository.Add(matriculaAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Aluno adicionado")
                : BadRequest("Erro ao salvar");
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, AlunoAtualizarDto aluno)
        {
            if (id <= 0) return BadRequest("Aluno não informado");

            var alunoBanco = await _repository.GetAlunosByIdAsync(id);

            var alunoAtualizar = _mapper.Map(aluno, alunoBanco);

            _repository.Update(alunoAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Aluno atualizado")
                : BadRequest("Erro ao atualizar");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Aluno Invalido");

            var alunoExcluir = await _repository.GetAlunosByIdAsync(id);

            if (alunoExcluir == null) return NotFound("Aluno não encontrado");

            _repository.Delete(alunoExcluir);

            return await _repository.SaveChangesAsync()
                ? Ok("Aluno deletado")
                : BadRequest("Erro ao deletar");
        }

        [HttpGet("matricula")]
        public async Task<IActionResult> GetAlunosTurmaAsync()
        {
            var matricula = await _repository.GetAlunosTurmasAsync();
            return matricula.Any()
                ? Ok(matricula)
                : BadRequest("Matriculas não encotradas");
        }

        [HttpPost("matricula")]
        public async Task<IActionResult> Post(AlunoTurmaPostDto matricula)
        {
            int alunoId = matricula.AlunoId;
            int turmaId = matricula.TurmaId;


            if (alunoId <= 0 || turmaId <= 0) return BadRequest("Dados invalidos");

            var matriculabanco = await _repository.GetAlunosTurmasIdAsync(alunoId, turmaId);

            if (matriculabanco != null) return Ok("Matricula já existe");

            var testarIdTurma = await _repository.GetTurmaByIdAsync(turmaId);

            if (testarIdTurma == null) return BadRequest("Id de turma não existe");

            var testarIdAluno = await _repository.GetAlunosByIdAsync(alunoId);

            if (testarIdAluno == null) return BadRequest("Id de aluno não existe");

            var ContarAlunosNaTurma = await _repository.ContarAlunosNaTurma(turmaId);

            if (ContarAlunosNaTurma.Count >= 5) return BadRequest("Turma cheia");

            var matriculaAdicionar = new AlunoTurma
            {
                AlunoId = alunoId,
                TurmaId = turmaId
            };

            _repository.Add(matriculaAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Matricula realizada")
                : BadRequest("Erro ao matricular");
        }

        [HttpDelete("matricula {id}")]
        public async Task<IActionResult> DeleteMatricula(int id)
        {
            if (id <= 0) return BadRequest("Matricula Invalida");

            var alunoExcluir = await _repository.GetAlunosTurmasByIdAsync(id);

            if (alunoExcluir == null) return NotFound("Matricula não encontrada");

            _repository.Delete(alunoExcluir);

            return await _repository.SaveChangesAsync()
                ? Ok("Matricula deletada")
                : BadRequest("Erro ao deletar");
        }

    }
}
