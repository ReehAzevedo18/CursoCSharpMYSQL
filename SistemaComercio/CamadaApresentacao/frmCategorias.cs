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
            if (e.ColumnIndex == dataLista.Columns["Deletar"].Index)
            {
                //Quando for necessario clicar em um checkbox dentro do datagrid
                DataGridViewCheckBoxCell chkDeletar = (DataGridViewCheckBoxCell)dataLista.Rows[e.RowIndex].Cells["Deletar"];
                chkDeletar.Value = !Convert.ToBoolean(chkDeletar.Value);
            }
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.ehnovo = true;
            this.ehEditar = false;
            this.habilitarBotoes();
            this.limparCampos();
            this.habilitar(true);
            this.txtNome.Focus();
            this.txtIDCategoria.Enabled = false;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                if(this.txtNome.Text == string.Empty)
                {
                   //ttMensagem("Preencha todos os campos");
                   errorIcone.SetError(txtNome, "Insira o nome");
                }
                else
                {
                    if (this.ehnovo)
                    {
                        resp = NCategoria.Inserir(this.txtNome.Text.Trim().ToUpper(), this.txtDescricao.Text.Trim());
                    }
                    else
                    {
                        resp = NCategoria.Editar(Convert.ToInt32(this.txtIDCategoria.Text),
                                                                 this.txtNome.Text.Trim().ToUpper(),
                                                                 this.txtDescricao.Text.Trim());
                    }
                    if (resp.Equals("OK"))
                    {
                        if (this.ehnovo)
                        {
                            this.mensagem("Registro salvo com sucesso.");
                        }
                        else
                        {
                            this.mensagem("Registro editado com sucesso.");
                        }
                    }
                    else
                    {
                        this.erro(resp);
                    }

                    this.ehnovo = false;
                    this.ehEditar = false;
                    this.habilitarBotoes();
                    this.limparCampos();
                    this.Mostrar();
                }
            }
            catch(Exception ex)
            {
                //codigo do erro
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataLista_DoubleClick(object sender, EventArgs e)
        {
            //Recuperando do BD o conteudo de acordo com o ID
            this.txtIDCategoria.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["idcategoria"].Value);
            this.txtNome.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["nome"].Value);
            this.txtDescricao.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["descricao"].Value);
            //Pegou as informações que estavam na lista da aba de Configurações.
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtIDCategoria.Text.Equals(""))
            {
                this.erro("Selecione um registro para inserir.");
            }
            else
            {
                this.ehEditar = true;
                this.habilitarBotoes();
                this.habilitar(true);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ehnovo = false;
            this.ehEditar = false;
            this.habilitarBotoes();
            this.habilitar(false);
            this.limparCampos();
        }

        private void chkDeletar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletar.Checked)
            {
                this.dataLista.Columns[0].Visible = true;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try 
            {
                DialogResult opcao;
                opcao = MessageBox.Show("Realmente deseja apagar os registros?", "Sistema Comércio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(opcao == DialogResult.OK)
                {
                    string codigo;
                    string resp = "";

                    foreach(DataGridViewRow row in dataLista.Rows)
                    {
                        //Se a celula receber um valor verdadeiro, ela será marcada
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //posição 1 > id da categoria
                            codigo = Convert.ToString(row.Cells[1].Value);
                            resp = NCategoria.Excluir(Convert.ToInt32(codigo));

                            if (resp.Equals("OK"))
                            {
                                this.mensagem("Registro excluído com sucesso.");

                            }
                            else
                            {
                                this.erro(resp);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch
            {

            }

        }
    }
}
