using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Models.Entities
{
    public class AlunoTurma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public Aluno Alunos { get; set; }
        public int TurmaId { get; set; }
        public Turma Turmas { get; set; }

    }
}
