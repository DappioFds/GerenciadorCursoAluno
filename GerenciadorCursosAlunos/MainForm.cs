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

        // Inicializa os componentes da interface e configura o campo CPF
        // Tamb�m carrega os dados iniciais de categorias e cursos
        public MainForm()
        {
            InitializeComponent();
            ConfigurarTxtCpf();
            InicializarDados();
        }

        // Cria categorias e cursos iniciais do sistema para exemplo e testes
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

        // Atualiza a lista de cursos exibida no formul�rio com base nos dados dispon�veis
        private void AtualizarListaCursos()
        {
            clbCursos.Items.Clear();
            foreach (var curso in cursos)
                clbCursos.Items.Add(curso);
        }

        // Preenche o ComboBox de categorias com as existentes e seleciona a op��o "Todas"
        private void AtualizarComboCategorias()
        {
            cmbCategorias.Items.Clear();
            cmbCategorias.Items.Add("Todas");
            foreach (var cat in categorias)
                cmbCategorias.Items.Add(cat);
            cmbCategorias.SelectedIndex = 0;
        }

        // Se a op��o "Todas" for selecionada, exibe todos os cursos
        // Caso contr�rio, filtra e exibe apenas cursos da categoria selecionada
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

        // Limpa erros anteriores e coleta os dados inseridos pelo usu�rio
        private void btnAdicionarAluno_Click(object sender, EventArgs e)
        {
            LimparErrosValidacao();

            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cpf = txtCpf.Text.Trim();
            string matricula = txtMatricula.Text.Trim();

            bool temErro = false;

            // Valida��o do Nome
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3)
            {
                txtNome.BackColor = Color.MistyRose;
                lblErroNome.Text = "O nome deve ter pelo menos 3 letras.";
                temErro = true;
            }

            // Valida��o do Cpf (tem que conter 11 digitos)
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
            {
                txtCpf.BackColor = Color.MistyRose;
                lblErroCpf.Text = "CPF inv�lido";
                temErro = true;
            }

            // Valida��o da Matr�cula (tem que ter 9 digitos)
            if (string.IsNullOrWhiteSpace(matricula) || matricula.Length != 9 || !long.TryParse(matricula, out _))
            {
                txtMatricula.BackColor = Color.MistyRose;
                lblErroMatricula.Text = "Matr�cula inv�lida. Use 9 d�gitos num�ricos.";
                temErro = true;
            }

            // Valida��o dos Cursos selecionados
            if (clbCursos.CheckedItems.Count == 0)
            {
                MessageBox.Show("O aluno deve estar em pelo menos um Curso.");
                temErro = true;
            }

            if (temErro)
            {
                return;
            }

            // Verifica se j� existe aluno com mesmo CPF ou matr�cula
            var alunoExistente = alunos.Find(a => a.Cpf == cpf || a.Matricula == matricula);

            if (alunoExistente != null)
            {
                // Verifica se � o MESMO aluno (nome e email iguais)
                if (alunoExistente.Nome == nome && alunoExistente.Email == email)
                {
                    // Apenas adiciona os novos cursos (evita duplicar cursos)
                    foreach (Curso curso in clbCursos.CheckedItems)
                    {
                        alunoExistente.Matricular(curso);
                    }

                    MessageBox.Show("Aluno j� existia. Cursos atualizados com sucesso!");
                }

                // Se existe outro aluno com mesmo CPF/matr�cula mas com dados diferentes, mostra erro
                else
                {
                    MessageBox.Show("J� existe um aluno com o mesmo CPF ou matr�cula, mas com dados diferentes (nome ou email). Verifique os dados.");
                    return;
                }
            }
            // Caso contr�rio, cria um novo aluno e o adiciona � lista
            else
            {
                // Cria novo aluno
                var novoAluno = new Aluno(nome, email, cpf, matricula);
                foreach (Curso curso in clbCursos.CheckedItems)
                {
                    novoAluno.Matricular(curso);
                }

                alunos.Add(novoAluno);
                lstAlunos.Items.Add(novoAluno);

                MessageBox.Show("Aluno adicionado com sucesso!");
            }

            // Limpa os campos de entrada e desmarca todos os cursos ap�s o cadastro

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

        // Exibe as informa��es detalhadas do aluno selecionado
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
            // Permite apenas n�meros e tecla Backspace
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

        // Solicita ao usu�rio o nome de uma nova categoria
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

        // Ajusta o cursor para facilitar a digita��o no formato do CPF
        private void txtCpf_Click(object sender, EventArgs e)
        {
            AjustarCursorCpf();
        }
        private void AjustarCursorCpf()
        {
            // Move o cursor para a primeira posi��o dispon�vel para digita��o, sempre da esquerda para direita
            int pos = txtCpf.Text.IndexOf(' ');
            if (pos == -1)
            {
                // Tudo preenchido, deixa cursor no final
                pos = txtCpf.Text.Length;
            }
            txtCpf.SelectionStart = pos;
        }

        // Bloqueia setas e Home/End para impedir mudar a posi��o do cursor
        private void TxtCpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
            {
                e.Handled = true;
            }
        }

        // Permite apenas n�meros, backspace e impede digitar no meio do texto
        private void TxtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Impede digitar se o cursor n�o estiver na primeira posi��o dispon�vel
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

        // Mant�m a propor��o 16:9 da janela ao ser redimensionada, evitando distor��es
        private void MainForm_Resize(object sender, EventArgs e)
        {
            int novaLargura = this.Width;
            int novaAltura = this.Height;

            float proporcaoAtual = (float)novaLargura / novaAltura;

            if (proporcaoAtual > proporcaoOriginal)
            {
                // Janela est� muito larga, ajusta largura para manter propor��o
                novaLargura = (int)(novaAltura * proporcaoOriginal);
                this.Width = novaLargura;
            }
            else if (proporcaoAtual < proporcaoOriginal)
            {
                // Janela est� muito alta, ajusta altura para manter propor��o
                novaAltura = (int)(novaLargura / proporcaoOriginal);
                this.Height = novaAltura;
            }
        }

        //remover aluno
        private void btnRemoverAluno_Click_1(object sender, EventArgs e)
        {
            if (lstAlunos.SelectedItem is Aluno alunoSelecionado)
            {
                var confirmacao = MessageBox.Show(
                    $"Tem certeza que deseja remover o aluno:\n\n{alunoSelecionado.Nome}?",
                    "Confirmar Remo��o",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacao == DialogResult.Yes)
                {
                    alunos.Remove(alunoSelecionado);
                    lstAlunos.Items.Remove(alunoSelecionado);
                    MessageBox.Show("Aluno removido com sucesso!");
                }
            }
            else
            {
                MessageBox.Show("Selecione um aluno para remover.");
            }
        }
    }
}
