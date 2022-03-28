using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Models.Dtos
{
    public class AlunoAdicionarDto
    {

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }
        public int TurmaId { get; set; }
    }
}
