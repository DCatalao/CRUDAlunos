using System;
using System.Windows.Forms;
using Biblioteca;

namespace CRUDAlunos.Forms
{
    public partial class EditarAlunoForm : Form
    {
        Aluno editado;

        Form1 form;

        //Aqui se inicializa o Aluno porque ele vai buscar o Aluno que selecionamos que queremos editar, apenas ele
        //também inicializamos o Form1 porque precisaremos depois actualizar a lista que é mostrada na listbox
        public EditarAlunoForm(Form1 frm, Aluno editado)
        {
            InitializeComponent();

            this.editado = editado;
            form = frm;

            textBoxID.Text = editado.Id.ToString();
            textBoxPrimeiroNome.Text = editado.Nome;
            textBoxApelido.Text = editado.Apelido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {
                editado.Nome = textBoxPrimeiroNome.Text;
                editado.Apelido = textBoxApelido.Text;
                form.initLista();
                this.Close();
            }            
        }

        //copia do form1 que por coincidência tem os mesmo nomes e por isso podemos re-utilizar neste form
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
                    "O Aluno não vai ser editado",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            textBoxPrimeiroNome.Text = string.Empty;
            textBoxApelido.Text = string.Empty;
            this.Close();
        }
    }
}
