using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados
{
    public class DCategorias
    {
        private int _IdCategoria;
        private string _Nome;
        private string _Descricao;
        private string _TextoBuscar;

        //GET > Receber E SET > Enviar
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Construtor vazio
        public DCategorias() { }

        //Construtor com parametros -- Relacionar os campos de get e set com as variaveis criadas aqui no construtor
        public DCategorias(int idCategoria, string Nome, string Descricao, string BuscarNome)
        {
            this.IdCategoria = idCategoria;
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.TextoBuscar = BuscarNome;
        }

        //Método Inserir
        public string Inserir(DCategorias Categoria)
        {
            string resp = "";
            SqlConnection sqlConn = new SqlConnection(); /*Criando a conexão*/
            try
            {
                //Vai tentar a conexão e carregar as informações
                sqlConn.ConnectionString = Conection.Cn;
                sqlConn.Open(); //abrindo conexão

                //Inserindo na tabela
                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.Connection = sqlConn;
                sqlCMD.CommandText = ""; //inserir a procedure criada para inserção
                sqlCMD.CommandType = CommandType.StoredProcedure; //executar a procedure

                //Inicializando os parametros do BD
                SqlParameter ParIDCategoria = new SqlParameter();
                ParIDCategoria.ParameterName = "@idcategoria"; //campo da tabela categoria
                ParIDCategoria.SqlDbType = SqlDbType.Int; //tipo do campo
                ParIDCategoria.Direction = ParameterDirection.Output; //diração do campo
                sqlCMD.Parameters.Add(ParIDCategoria); //adicionei o campo do BD na variavel parIDCategoria

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Categoria.Nome;
                sqlCMD.Parameters.Add(ParNome);


                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 256;
                ParDescricao.Value = Categoria.Nome;
                sqlCMD.Parameters.Add(ParDescricao);

                //Executar comandos
                resp = sqlCMD.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi inserido"; //Verificar se a inserção vai funcionar


            }
            catch (Exception ex)
            {
                //Caso o try dê erro ele será acionado
                //resp = "Erro ao salvar!"; para o cliente
                resp = ex.Message; //saber qual erro deu
            }
            finally //será executado independente se cair no Catch ou não
            {
                if (sqlConn.State == ConnectionState.Open) //verifiquei o status da conexão, se for ABERTA
                    sqlConn.Close(); //será fechada
            }
            return resp;


        }

        public string Editar(DCategorias Categoria)
        {
            string resp = "";
            SqlConnection sqlConn = new SqlConnection(); /*Criando a conexão*/
            try
            {
                //Vai tentar a conexão e carregar as informações
                sqlConn.ConnectionString = Conection.Cn;
                sqlConn.Open(); //abrindo conexão

                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.Connection = sqlConn;
                sqlCMD.CommandText = ""; 
                sqlCMD.CommandType = CommandType.StoredProcedure; //executar a procedure

                //Inicializando os parametros do BD
                SqlParameter ParIDCategoria = new SqlParameter();
                ParIDCategoria.ParameterName = "@idcategoria"; //campo da tabela categoria
                ParIDCategoria.SqlDbType = SqlDbType.Int; //tipo do campo
                ParIDCategoria.Value = Categoria.IdCategoria; //como é edição, preciso pegar o valor do campo
                sqlCMD.Parameters.Add(ParIDCategoria); //adicionei o campo do BD na variavel parIDCategoria

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Categoria.Nome;
                sqlCMD.Parameters.Add(ParNome);


                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 256;
                ParDescricao.Value = Categoria.Descricao;
                sqlCMD.Parameters.Add(ParDescricao);

                //Executar comandos
                resp = sqlCMD.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi editado"; //Verificar se a inserção vai funcionar


            }
            catch (Exception ex)
            {
                //Caso o try dê erro ele será acionado
                //resp = "Erro ao salvar!"; para o cliente
                resp = ex.Message; //saber qual erro deu
            }
            finally //será executado independente se cair no Catch ou não
            {
                if (sqlConn.State == ConnectionState.Open) //verifiquei o status da conexão, se for ABERTA
                    sqlConn.Close(); //será fechada
            }
            return resp;


        }

        public string Excluir(DCategorias Categoria)
        {

            string resp = "";
            SqlConnection sqlConn = new SqlConnection(); /*Criando a conexão*/
            try
            {
                //Vai tentar a conexão e carregar as informações
                sqlConn.ConnectionString = Conection.Cn;
                sqlConn.Open(); //abrindo conexão

                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.Connection = sqlConn;
                sqlCMD.CommandText = "";
                sqlCMD.CommandType = CommandType.StoredProcedure; //executar a procedure

                //Inicializando os parametros do BD
                SqlParameter ParIDCategoria = new SqlParameter();
                ParIDCategoria.ParameterName = "@idcategoria"; //campo da tabela categoria
                ParIDCategoria.SqlDbType = SqlDbType.Int; //tipo do campo
                ParIDCategoria.Value = Categoria.IdCategoria; 
                sqlCMD.Parameters.Add(ParIDCategoria); //adicionei o campo do BD na variavel parIDCategoria


                //Executar comandos
                resp = sqlCMD.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi exlcuido"; //Verificar se a inserção vai funcionar


            }
            catch (Exception ex)
            {
                //Caso o try dê erro ele será acionado
                //resp = "Erro ao salvar!"; para o cliente
                resp = ex.Message; //saber qual erro deu
            }
            finally //será executado independente se cair no Catch ou não
            {
                if (sqlConn.State == ConnectionState.Open) //verifiquei o status da conexão, se for ABERTA
                    sqlConn.Close(); //será fechada
            }
            return resp;


        }

        //Mostrar dados do banco
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria"); //Instanciando a tabela categoria
            SqlConnection sqlConn = new SqlConnection();

            try 
            {
                sqlConn.ConnectionString = Conection.Cn;
                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.Connection = sqlConn;
                sqlCMD.CommandText = "";
                sqlCMD.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCMD); //mostrar os dados
                sqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        //Método Buscar Nome
        public DataTable BuscarNome(DCategorias Categoria)
        {
            DataTable DtResultado = new DataTable("categoria"); //Instanciando a tabela categoria
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn.ConnectionString = Conection.Cn;
                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.Connection = sqlConn;
                sqlCMD.CommandText = "";
                sqlCMD.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCMD); //mostrar os dados
                sqlDat.Fill(DtResultado);

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                sqlCMD.Parameters.Add(ParTextoBuscar);


            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }


}
