using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Models
{
    public class Turma
    {
        public int Id { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo número é obrigatorio")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo ano é obrigatorio")]
        public int Ano { get; set; }

        [MaxLength(5, ErrorMessage = "Turma só pode ter 5 alunos")]
        public List<Aluno> Alunos { get; set; }
    }
}
