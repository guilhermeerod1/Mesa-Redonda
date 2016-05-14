using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DL;
using Oracle.ManagedDataAccess.Client;

namespace DAL
{
    public class UsuarioDA
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public int Inserir(Usuario u)
        {

            using (OracleConnection conexao = new OracleConnection(connectionString))
            {

                conexao.Open();

                OracleCommand comando = new OracleCommand();
                
                comando.Connection = conexao;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "InserirUsuario";

                comando.Parameters.Add("cnome", OracleDbType.Varchar2).Value = u.Nome;
                comando.Parameters.Add("csenha", OracleDbType.Varchar2).Value = u.Senha;
                comando.Parameters.Add("ctipo", OracleDbType.Char).Value = u.Administrador ? "1" : "0";
                comando.Parameters.Add("cemail", OracleDbType.Varchar2).Value = u.Email;
                comando.Parameters.Add("ctelefone", OracleDbType.Varchar2).Value = u.Telefone;

                return comando.ExecuteNonQuery();

            }

        }

        public int Atualizar(Usuario u)
        {

            using (OracleConnection conexao = new OracleConnection(connectionString))
            {

                conexao.Open();

                OracleCommand comando = new OracleCommand();

                comando.Connection = conexao;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "AtualizarUsuario";

                comando.Parameters.Add("id", OracleDbType.Int32).Value = u.IdUsuario;
                comando.Parameters.Add("cnome", OracleDbType.Varchar2).Value = u.Nome;
                comando.Parameters.Add("csenha", OracleDbType.Varchar2).Value = u.Senha;
                comando.Parameters.Add("ctipo", OracleDbType.Char).Value = u.Administrador ? "1" : "0";
                comando.Parameters.Add("cemail", OracleDbType.Varchar2).Value = u.Email;
                comando.Parameters.Add("ctelefone", OracleDbType.Varchar2).Value = u.Telefone;

                return comando.ExecuteNonQuery();

            }

        }

        public int Remover(int id)
        {

            using (OracleConnection conexao = new OracleConnection(connectionString))
            {

                conexao.Open();

                OracleCommand comando = new OracleCommand();

                comando.Connection = conexao;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "DeletarUsuario";

                comando.Parameters.Add("id", OracleDbType.Int32).Value = id;

                return comando.ExecuteNonQuery();

            }

        }

        public List<Usuario> listar()
        {

            List<Usuario> lista = new List<Usuario>();

            using (OracleConnection conexao = new OracleConnection(connectionString))
            {

                conexao.Open();

                OracleCommand comando = new OracleCommand();

                comando.Connection = conexao;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select IdUsuario, Nome, Senha, Tipo, Email, Telefone from Usuarios order by IdUsuario";

                using (OracleDataReader reader = comando.ExecuteReader())
                {

                    while(reader.Read())
                    {
                        Usuario u = new Usuario();

                        u.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        u.Nome = (string)reader["Nome"];
                        u.Senha = (string)reader["Senha"];
                        u.Administrador = ((string)reader["Tipo"]).Equals("1");
                        u.Email = (string)reader["Email"];
                        u.Telefone = (string)reader["Telefone"];

                        lista.Add(u);

                    }

                }
                
                return lista;

            }

        }

        public Usuario buscar(int id)
        {
            return listar().FirstOrDefault(x => x.IdUsuario == id);
        }

        public Usuario buscar(string nome)
        {
            return listar().FirstOrDefault(x => x.Nome == nome);
        }

    }
}
