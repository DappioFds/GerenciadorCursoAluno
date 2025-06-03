using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCursosAlunos
{
    public class Curso
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }

        public Curso(string nome, Categoria categoria)
        {
            Nome = nome;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return Nome;
        }

        public List<Aluno> AlunosMatriculados { get; } = new();

        public void AdicionarAluno(Aluno aluno)
        {
            if (!AlunosMatriculados.Contains(aluno))
                AlunosMatriculados.Add(aluno);
        }
    }

}
