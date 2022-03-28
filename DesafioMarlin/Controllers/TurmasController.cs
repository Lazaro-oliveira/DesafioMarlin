using AutoMapper;
using DesafioMarlin.Models;
using DesafioMarlin.Models.Dtos;
using DesafioMarlin.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaRepository _repository;
        private readonly IMapper _mapper;

        public TurmasController(ITurmaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var turmas = await _repository.GetTurmasAsync();
            return turmas.Any()
                ? Ok(turmas)
                : BadRequest("Turmas não encotradas");
        }


        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var turma = await _repository.GetTurmasByIdAsync(id);
            return turma != null
                ? Ok(turma)
                : BadRequest("Turma não encotrada");
        }
        */

        [HttpPost]
        public async Task<IActionResult> Post(TurmaAdicionarDto turma)
        {
            if (turma == null) return BadRequest("Dados invalidos");

            var turmaAdicionar = _mapper.Map<Turma>(turma);

            _repository.Add(turmaAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Turma adicionada")
                : BadRequest("Erro ao salvar");
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, TurmaAdicionarDto turma)
        {
            if (id <= 0) return BadRequest("Turma não informada");

            var turmaBanco = await _repository.GetTurmasByIdAsync(id);

            if (turmaBanco == null) return BadRequest("Turma não Existe");

            var turmaAtualizar = _mapper.Map(turma, turmaBanco);

            _repository.Update(turmaAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Turma atualizada")
                : BadRequest("Erro ao atualizar");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Turma Invalida");

            var turmaExcluir = await _repository.GetTurmasByIdAsync(id);

            if (turmaExcluir == null) return NotFound("Turma não encontrada");

            var matricula = await _repository.GetAlunosTurmasByIdAsync(id);

            if (matricula != null) return BadRequest("Está turma possui alunos matriculados");

            _repository.Delete(turmaExcluir);

            return await _repository.SaveChangesAsync()
                ? Ok("Turma deletada")
                : BadRequest("Erro ao deletar");
        }
    }
}
