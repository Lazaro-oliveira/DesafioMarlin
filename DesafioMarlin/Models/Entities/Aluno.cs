using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Models
{
    public class Aluno
    {

        public int Id { get; set;}

        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "O campo CPF é obrigatorio")]
        [CpfValidation(ErrorMessage = "Cpf invalido")]
        public string Cpf { get; set; }

        [MinLength( 1 ,ErrorMessage = "Aluno precisa estar em pelo menos uma turma")]
        public List<Turma> Turmas { get; set; }



    }
}
