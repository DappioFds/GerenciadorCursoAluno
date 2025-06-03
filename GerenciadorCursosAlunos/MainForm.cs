using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorCursosAlunos
{
    public partial class MainForm : Form
    {
        private List<Aluno> alunos = new();
        private List<Curso> cursos = new();
        private List<Categoria> categorias = new();

        public MainForm()
        {
            InitializeComponent();
            ConfigurarTxtCpf();
            InicializarDados();
        }

        private void InicializarDados()
        {
            var catTI = new Categoria("TI");
            var catDesign = new Categoria("Design");
            categorias.Add(catTI);
            categorias.Add(catDesign);

            cursos.Add(new Curso("C#", catTI));
            cursos.Add(new Curso("Banco de Dados", catTI));
            cursos.Add(new Curso("Photoshop", catDesign));

            AtualizarComboCategorias();
            AtualizarListaCursos();
        }

        private void AtualizarListaCursos()
        {
            clbCursos.Items.Clear();
            foreach (var curso in cursos)
                clbCursos.Items.Add(curso);
        }

        private void AtualizarComboCategorias()
        {
            cmbCategorias.Items.Clear();
            cmbCategorias.Items.Add("Todas");
            foreach (var cat in categorias)
                cmbCategorias.Items.Add(cat);
            cmbCategorias.SelectedIndex = 0;
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbCursos.Items.Clear();
            if (cmbCategorias.SelectedItem?.ToString() == "Todas")
            {
                foreach (var curso in cursos)
                    clbCursos.Items.Add(curso);
            }
            else if (cmbCategorias.SelectedItem is Categoria categoria)
            {
                foreach (var curso in cursos)
                {
                    if (curso.Categoria == categoria)
                        clbCursos.Items.Add(curso);
                }
            }
        }

        private void btnAdicionarAluno_Click(object sender, EventArgs e)
        {
            LimparErrosValidacao();

            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cpf = txtCpf.Text.Trim();
            string matricula = txtMatricula.Text.Trim();

            bool temErro = false;

            // Nome
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3)
            {
                txtNome.BackColor = Color.MistyRose;
                lblErroNome.Text = "O nome deve ter pelo menos 3 letras.";
                temErro = true;
            }

            // Cpf
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
            {
                txtCpf.BackColor = Color.MistyRose;
                lblErroCpf.Text = "CPF inválido";
                temErro = true;
            }

            // Matrícula
            if (string.IsNullOrWhiteSpace(matricula) || matricula.Length != 9 || !long.TryParse(matricula, out _))
            {
                txtMatricula.BackColor = Color.MistyRose;
                lblErroMatricula.Text = "Matrícula inválida. Use 9 dígitos numéricos.";
                temErro = true;
            }

            // Cursos
            if (clbCursos.CheckedItems.Count == 0)
            {
                MessageBox.Show("O aluno deve estar em pelo menos um Curso.");
                temErro = true;
            }

            if (temErro)
            {
                return;
            }

            var aluno = new Aluno(nome, email, cpf, matricula);
            foreach (Curso curso in clbCursos.CheckedItems)
            {
                aluno.Matricular(curso);
            }

            alunos.Add(aluno);
            if (!lstAlunos.Items.Contains(aluno))
            {
                lstAlunos.Items.Add(aluno);
            }

            MessageBox.Show("Aluno adicionado com sucesso!");

            txtNome.Clear();
            txtEmail.Clear();
            txtCpf.Clear();
            txtMatricula.Clear();

            for (int i = 0; i < clbCursos.Items.Count; i++)
            {
                clbCursos.SetItemChecked(i, false);
            }

            LimparErrosValidacao();
        }

        private void btnExibirAluno_Click(object sender, EventArgs e)
        {
            if (lstAlunos.SelectedItem is Aluno aluno)
            {
                ExibirInformacoesDe(aluno);
            }
            else
            {
                MessageBox.Show("Selecione um Aluno.");
            }
        }


        private void ApenasNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LimparErrosValidacao()
        {
            txtNome.BackColor = SystemColors.Window;
            txtCpf.BackColor = SystemColors.Window;
            txtMatricula.BackColor = SystemColors.Window;

            lblErroNome.Text = "";
            lblErroCpf.Text = "";
            lblErroMatricula.Text = "";
        }

        private void btnCriarCursoCategoria_Click(object sender, EventArgs e)
        {
            string nomeCategoria = Microsoft.VisualBasic.Interaction.InputBox("Nome da nova categoria:", "Nova Categoria", "TI");
            if (string.IsNullOrWhiteSpace(nomeCategoria)) return;

            Categoria categoria = categorias.Find(c => c.Nome.Equals(nomeCategoria, StringComparison.OrdinalIgnoreCase));
            if (categoria == null)
            {
                categoria = new Categoria(nomeCategoria);
                categorias.Add(categoria);
                AtualizarComboCategorias();
            }

            string nomeCurso = Microsoft.VisualBasic.Interaction.InputBox("Nome do novo curso:", "Novo Curso", "Novo Curso");
            if (string.IsNullOrWhiteSpace(nomeCurso)) return;

            cursos.Add(new Curso(nomeCurso, categoria));
            AtualizarListaCursos();
            MessageBox.Show("Curso criado com sucesso!");
        }
        private void txtCpf_Click(object sender, EventArgs e)
        {
            AjustarCursorCpf();
        }
        private void AjustarCursorCpf()
        {
            // Move o cursor para a primeira posição disponível para digitação, sempre da esquerda para direita
            int pos = txtCpf.Text.IndexOf(' ');
            if (pos == -1)
            {
                // Tudo preenchido, deixa cursor no final
                pos = txtCpf.Text.Length;
            }
            txtCpf.SelectionStart = pos;
        }

        // Bloqueia setas e Home/End para impedir mudar a posição do cursor
        private void TxtCpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
            {
                e.Handled = true;
            }
        }

        // Permite apenas números, backspace e impede digitar no meio do texto
        private void TxtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Impede digitar se o cursor não estiver na primeira posição disponível
            int pos = txtCpf.SelectionStart;
            int primeiraPosicaoDisponivel = txtCpf.Text.IndexOf(' ');

            if (primeiraPosicaoDisponivel == -1)
                primeiraPosicaoDisponivel = txtCpf.Text.Length;

            if (pos != primeiraPosicaoDisponivel && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ConfigurarTxtCpf()
        {
            txtCpf.Mask = "000.000.000-00";
            txtCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCpf.ResetOnPrompt = false;
            txtCpf.ResetOnSpace = false;
            txtCpf.SkipLiterals = false;
            txtCpf.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            txtCpf.Click += txtCpf_Click;
            txtCpf.KeyDown += TxtCpf_KeyDown;
            txtCpf.KeyPress += TxtCpf_KeyPress;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        private void ExibirInformacoesDe(Aluno aluno)
        {
            aluno.ExibirInformacoes();
        }

        private readonly float proporcaoOriginal = 16f / 9f; 
        private void MainForm_Resize(object sender, EventArgs e)
        {
            int novaLargura = this.Width;
            int novaAltura = this.Height;

            float proporcaoAtual = (float)novaLargura / novaAltura;

            if (proporcaoAtual > proporcaoOriginal)
            {
                // Janela está muito larga, ajusta largura para manter proporção
                novaLargura = (int)(novaAltura * proporcaoOriginal);
                this.Width = novaLargura;
            }
            else if (proporcaoAtual < proporcaoOriginal)
            {
                // Janela está muito alta, ajusta altura para manter proporção
                novaAltura = (int)(novaLargura / proporcaoOriginal);
                this.Height = novaAltura;
            }
        }
    }
}
