using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRUDAlunos.Forms
{
    public partial class Form1 : Form
    {
        List<Aluno> Alunos;
        int contaAlunos = 6;

        public Form1()
        {
            Alunos = new List<Aluno>();
            Alunos.Add(new Aluno { Id = 1, Nome = "Maria", Apelido = "Albuquerque" });
            Alunos.Add(new Aluno { Id = 2, Nome = "João", Apelido = "Doria" });
            Alunos.Add(new Aluno { Id = 3, Nome = "Daniel", Apelido = "Cardozo" });
            Alunos.Add(new Aluno { Id = 4, Nome = "Gertrude", Apelido = "Jeremias" });
            Alunos.Add(new Aluno { Id = 5, Nome = "Oazenguito", Apelido = "Ferreira" });
            InitializeComponent();
            initLista();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Aluno novoAluno;
            if (ValidaForm())
            {
                novoAluno = new Aluno
                {
                    Id = contaAlunos,
                    Nome = textBoxPrimeiroNome.Text,
                    Apelido = textBoxApelido.Text,
                };

                Alunos.Add(novoAluno);
                contaAlunos++;
                initLista();
                
            }
            else
            {
                MessageBox.Show(
                    "Preencha corretamente os dados e tente novamente",
                    "Erro", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

            textBoxPrimeiroNome.Clear();
            textBoxApelido.Clear();
        }

        public void initLista()
        {
            listBoxAlunos.DataSource = null;
            //listBoxAlunos.DataSource = Alunos.toString(); 
            //é a mesma coisa que o de baixo, ele assume naturalmente mas
            //não mostra o to.String(); logo é necessário criar um override no método toString() para que ele 
            //apresente a informação que nós decidirmos, este método de override está criada na classe Aluno.
            listBoxAlunos.DataSource = Alunos;
            //A forma abaixo substitui a utilização do override, porém a propriedade da classe tem de existir, neste caso
            // é a propriedade NomeCompleto
            listBoxAlunos.DisplayMember = "NomeCompleto";
            
            
        }

        private bool ValidaForm()
        {
            bool output = true;

            if (string.IsNullOrEmpty(textBoxPrimeiroNome.Text))
            {
                MessageBox.Show(
                    "Insira o seu primeiro Nome", 
                    "Erro", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                output = false;
            }

            if (string.IsNullOrEmpty(textBoxApelido.Text))
            {
                MessageBox.Show(
                    "Insira o seu apelido", 
                    "Erro", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                output = false;
            }

            return output;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                    "O Aluno não vai ser guardado",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            textBoxPrimeiroNome.Text = string.Empty;
            textBoxApelido.Text = string.Empty;
        }

        private void btnApagarAluno_Click(object sender, EventArgs e)
        {
            //(Aluno)listBoxAlunos.SelectedItem; é uma conversão do listbox em formato "Aluno", é um "Cast" a moda antiga
            //então o algoritimo abaixo serve para buscar o item que foi selecionado na ListBox na nossa Lista e o
            //grava na variável alunoAApagar
            Aluno alunoAApagar = (Aluno)listBoxAlunos.SelectedItem;

            Aluno apagado = null;

            if (alunoAApagar != null)
            {
                foreach(Aluno aluno in Alunos)
                {
                    if(alunoAApagar.Id == aluno.Id)
                    {
                        apagado = aluno;
                    }
                }

                if(apagado!= null)
                {
                    DialogResult resposta;
                    resposta = MessageBox.Show($"Tem a Certeza que pretende apagar o {apagado.NomeCompleto}",
                        "Apagar",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);
                    if(DialogResult.OK == resposta)
                    {
                        Alunos.Remove(apagado);
                        initLista();
                    }
                }
            }
        }

        private void btnEditarAluno_Click(object sender, EventArgs e)
        {
            Aluno alunoAEditar = (Aluno)listBoxAlunos.SelectedItem;
            Aluno editado = null;

            if (alunoAEditar != null)
            {
                foreach(Aluno aluno in Alunos)
                {
                    if(alunoAEditar.Id == aluno.Id)
                    {
                        editado = aluno;
                    }
                }
                //abrir a nova form para editar
                if (editado != null)
                {
                    EditarAlunoForm editarAlunoForm = new EditarAlunoForm(this, editado);
                    editarAlunoForm.Show();
                }
                

            }
        }
    }
}
