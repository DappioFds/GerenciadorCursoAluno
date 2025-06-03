using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCursosAlunos
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        protected Pessoa(string nome, string email, string cpf)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }

}
