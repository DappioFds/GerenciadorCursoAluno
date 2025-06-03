namespace GerenciadorCursosAlunos
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNome = new Label();
            lblEmail = new Label();
            lblCpf = new Label();
            lblMatricula = new Label();
            lblCategoriaFiltro = new Label();
            lblCursos = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtMatricula = new TextBox();
            cmbCategorias = new ComboBox();
            clbCursos = new CheckedListBox();
            btnAdicionarAluno = new Button();
            btnCriarCursoCategoria = new Button();
            btnExibirAluno = new Button();
            lstAlunos = new ListBox();
            lblErroNome = new Label();
            lblErroCpf = new Label();
            lblErroMatricula = new Label();
            txtCpf = new MaskedTextBox();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(20, 22);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 83);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblCpf
            // 
            lblCpf.AutoSize = true;
            lblCpf.Location = new Point(20, 127);
            lblCpf.Name = "lblCpf";
            lblCpf.Size = new Size(28, 15);
            lblCpf.TabIndex = 2;
            lblCpf.Text = "CPF";
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Location = new Point(20, 187);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(57, 15);
            lblMatricula.TabIndex = 3;
            lblMatricula.Text = "Matrícula";
            // 
            // lblCategoriaFiltro
            // 
            lblCategoriaFiltro.AutoSize = true;
            lblCategoriaFiltro.Location = new Point(20, 249);
            lblCategoriaFiltro.Name = "lblCategoriaFiltro";
            lblCategoriaFiltro.Size = new Size(112, 15);
            lblCategoriaFiltro.TabIndex = 4;
            lblCategoriaFiltro.Text = "Filtrar por Categoria";
            // 
            // lblCursos
            // 
            lblCursos.AutoSize = true;
            lblCursos.Location = new Point(20, 302);
            lblCursos.Name = "lblCursos";
            lblCursos.Size = new Size(43, 15);
            lblCursos.TabIndex = 5;
            lblCursos.Text = "Cursos";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(20, 40);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(288, 23);
            txtNome.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 101);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(288, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(20, 205);
            txtMatricula.MaxLength = 9;
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(288, 23);
            txtMatricula.TabIndex = 9;
            txtMatricula.KeyPress += ApenasNumeros_KeyPress;
            // 
            // cmbCategorias
            // 
            cmbCategorias.FormattingEnabled = true;
            cmbCategorias.Location = new Point(20, 267);
            cmbCategorias.Name = "cmbCategorias";
            cmbCategorias.Size = new Size(189, 23);
            cmbCategorias.TabIndex = 10;
            cmbCategorias.SelectedIndexChanged += cmbCategorias_SelectedIndexChanged;
            // 
            // clbCursos
            // 
            clbCursos.FormattingEnabled = true;
            clbCursos.Location = new Point(20, 320);
            clbCursos.Name = "clbCursos";
            clbCursos.Size = new Size(189, 112);
            clbCursos.TabIndex = 11;
            // 
            // btnAdicionarAluno
            // 
            btnAdicionarAluno.Location = new Point(20, 445);
            btnAdicionarAluno.Name = "btnAdicionarAluno";
            btnAdicionarAluno.Size = new Size(137, 56);
            btnAdicionarAluno.TabIndex = 12;
            btnAdicionarAluno.Text = "Adicionar Aluno";
            btnAdicionarAluno.UseVisualStyleBackColor = true;
            btnAdicionarAluno.Click += btnAdicionarAluno_Click;
            // 
            // btnCriarCursoCategoria
            // 
            btnCriarCursoCategoria.Location = new Point(20, 569);
            btnCriarCursoCategoria.Name = "btnCriarCursoCategoria";
            btnCriarCursoCategoria.Size = new Size(137, 56);
            btnCriarCursoCategoria.TabIndex = 13;
            btnCriarCursoCategoria.Text = "Adicionar nova Categoria/Curso";
            btnCriarCursoCategoria.UseVisualStyleBackColor = true;
            btnCriarCursoCategoria.Click += btnCriarCursoCategoria_Click;
            // 
            // btnExibirAluno
            // 
            btnExibirAluno.Location = new Point(20, 507);
            btnExibirAluno.Name = "btnExibirAluno";
            btnExibirAluno.Size = new Size(137, 56);
            btnExibirAluno.TabIndex = 14;
            btnExibirAluno.Text = "Exibir Informações do Aluno";
            btnExibirAluno.UseVisualStyleBackColor = true;
            btnExibirAluno.Click += btnExibirAluno_Click;
            // 
            // lstAlunos
            // 
            lstAlunos.FormattingEnabled = true;
            lstAlunos.ItemHeight = 15;
            lstAlunos.Location = new Point(469, 22);
            lstAlunos.Name = "lstAlunos";
            lstAlunos.Size = new Size(701, 604);
            lstAlunos.TabIndex = 15;
            // 
            // lblErroNome
            // 
            lblErroNome.AutoSize = true;
            lblErroNome.Location = new Point(20, 66);
            lblErroNome.Name = "lblErroNome";
            lblErroNome.Size = new Size(0, 15);
            lblErroNome.TabIndex = 16;
            // 
            // lblErroCpf
            // 
            lblErroCpf.AutoSize = true;
            lblErroCpf.Location = new Point(20, 171);
            lblErroCpf.Name = "lblErroCpf";
            lblErroCpf.Size = new Size(0, 15);
            lblErroCpf.TabIndex = 17;
            // 
            // lblErroMatricula
            // 
            lblErroMatricula.AutoSize = true;
            lblErroMatricula.Location = new Point(20, 231);
            lblErroMatricula.Name = "lblErroMatricula";
            lblErroMatricula.Size = new Size(0, 15);
            lblErroMatricula.TabIndex = 18;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(20, 145);
            txtCpf.Mask = "000.000.000-00";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(288, 23);
            txtCpf.TabIndex = 19;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 688);
            Controls.Add(txtCpf);
            Controls.Add(lblErroMatricula);
            Controls.Add(lblErroCpf);
            Controls.Add(lblErroNome);
            Controls.Add(lstAlunos);
            Controls.Add(btnExibirAluno);
            Controls.Add(btnCriarCursoCategoria);
            Controls.Add(btnAdicionarAluno);
            Controls.Add(clbCursos);
            Controls.Add(cmbCategorias);
            Controls.Add(txtMatricula);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(lblCursos);
            Controls.Add(lblCategoriaFiltro);
            Controls.Add(lblMatricula);
            Controls.Add(lblCpf);
            Controls.Add(lblEmail);
            Controls.Add(lblNome);
            MinimumSize = new Size(1200, 680);
            Name = "MainForm";
            Text = "Gerenciador de Alunos";
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblEmail;
        private Label lblCpf;
        private Label lblMatricula;
        private Label lblCategoriaFiltro;
        private Label lblCursos;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtMatricula;
        private ComboBox cmbCategorias;
        private CheckedListBox clbCursos;
        private Button btnAdicionarAluno;
        private Button btnCriarCursoCategoria;
        private Button btnExibirAluno;
        private ListBox lstAlunos;
        private Label lblErroNome;
        private Label lblErroCpf;
        private Label lblErroMatricula;
        private MaskedTextBox txtCpf;
    }
}
