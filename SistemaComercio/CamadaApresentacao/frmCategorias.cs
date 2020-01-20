using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaNegocio;

namespace CamadaApresentacao
{
    public partial class frmCategorias : Form
    {
        //Para verificar quando for novo e quando for edição
        private bool ehnovo = false;
        private bool ehEditar = false;

        public frmCategorias()
        {
            InitializeComponent();
            //tolltip serve para quando o usuario posicionar o mouse emcima do textbox mostrar uma mensagem
            this.ttMensagem.SetToolTip(this.txtNome, "Insira o nome da Categoria!");
        }

        //Mostrar mensagem de confirmação
        private void mensagem(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema de Comércio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensagem de erro
        private void erro(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema de Comércio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpar dados
        private void limparCampos()
        {
            this.txtNome.Text = string.Empty;
            this.txtIDCategoria.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
        }

        //Habilitar os textbox
        private void habilitar(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.txtDescricao.ReadOnly = !valor;
            this.txtIDCategoria.ReadOnly = !valor;
        }

        //Habilitar botões
        private void habilitarBotoes()
        {
            if(this.ehnovo || this.ehEditar)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {

        }
    }
}
