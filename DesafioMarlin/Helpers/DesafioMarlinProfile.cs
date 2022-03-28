using AutoMapper;
using DesafioMarlin.Models;
using DesafioMarlin.Models.Dtos;
using DesafioMarlin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Helpers
{
    public class DesafioMarlinProfile : Profile
    {
        public DesafioMarlinProfile() 
        {
            CreateMap<AlunoAdicionarDto, Aluno>();
            CreateMap<AlunoAtualizarDto, Aluno>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));//se um atributo for mandado como nulo ele não será atualizado

            CreateMap<AlunoInserirDto, Aluno>();
            CreateMap<AlunoTurmaPostDto, AlunoTurma>();

            CreateMap<TurmaAdicionarDto, Turma>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Aluno, AlunoDto>();

            CreateMap<Aluno, AlunoDetalhesDto>()
                .ForMember(dest => dest.Turma, opt => opt.MapFrom(src =>
                src.Turmas.Select(x => x.Id).ToArray()));

            CreateMap<AlunoTurma, AlunoTurmaDto>();
        }
    }
}
