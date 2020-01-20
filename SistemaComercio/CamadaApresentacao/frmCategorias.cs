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
                //Retirar de apenas leitura quando for novo ou editar
                this.habilitar(true);
                this.btnNovo.Enabled = false; //se já está dentro da função novo, ele não pode estar habilitado
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Ocultar as colunas do grid
        private void ocultarColunasGrid()
        {
            this.dataLista.Columns[0].Visible = false; //coluna deletar
            //this.dataLista.Columns[1].Visible = false; //coluna do ID
        }

        private void Mostrar()
        {
            this.dataLista.DataSource = NCategoria.Mostrar(); //mostrar os dados no grid da função na camada de negócios
            this.ocultarColunasGrid();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count); //total de registros no BD
        }

        private void BuscarNome()
        {
            this.dataLista.DataSource = NCategoria.BuscarNome(this.txtbuscar.Text); //mostrar os dados no grid da função na camada de negócios
            this.ocultarColunasGrid();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count); //total de registros no BD
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.habilitar(false);
            this.habilitarBotoes();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            //textChanged = realiza a busca de acordo com o que é digitado
            this.BuscarNome();
        }
    }
}
