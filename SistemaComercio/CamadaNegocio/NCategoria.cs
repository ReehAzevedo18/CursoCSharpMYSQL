using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    //Precisa por como publica pois será acessar de outras camadas
    public class NCategoria
    {
        public static string Inserir(string nome, string descricao)
        {
            DCategorias obj = new CamadaDados.DCategorias();
            obj.Nome = nome;
            obj.Descricao = descricao;
            return obj.Inserir(obj);

        }

        public static string Editar(int idcategoria, string nome, string descricao)
        {
            DCategorias obj = new CamadaDados.DCategorias();
            obj.IdCategoria = idcategoria;
            obj.Nome = nome;
            obj.Descricao = descricao;
            return obj.Editar(obj);

        }

        public static string Excluir(int idcategoria)
        {
            DCategorias obj = new CamadaDados.DCategorias();
            obj.IdCategoria = idcategoria;
            return obj.Excluir(obj);

        }

        public static DataTable Mostrar()
        {
            return new DCategorias().Mostrar();
        }

        public static DataTable BuscarNome(string textobuscar)
        {
            DCategorias obj = new DCategorias();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNome(obj);
        }


    }

}
