﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Models.Dtos
{
    public class AlunoDetalhesDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int[] Turma { get; set; }


    }
}
