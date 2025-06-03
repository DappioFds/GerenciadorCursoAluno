using GerenciadorCursosAlunos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static GerenciadorCursosAlunos.MainForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

public class Aluno : Pessoa, IExibivel
{
    public string Matricula { get; set; }
    public List<Curso> CursosMatriculados { get; set; } = new();

    public Aluno(string nome, string email, string cpf, string matricula)
        : base(nome, email, cpf)
    {
        Matricula = matricula;
    }

    public void Matricular(Curso curso)
    {
        if (!CursosMatriculados.Contains(curso))
        {
            CursosMatriculados.Add(curso);
            curso.AdicionarAluno(this);
        }
    }

    public void ExibirInformacoes()
    {
        string cursos = string.Join(", ", CursosMatriculados.ConvertAll(c => c.Nome));
        MessageBox.Show($"Nome: {Nome}\nEmail: {Email}\nCPF: {Cpf}\nMatrícula: {Matricula}\nCursos: {cursos}");
    }

    public override string ToString()
    {
        return $"{Nome} - {Matricula}";
    }
}
