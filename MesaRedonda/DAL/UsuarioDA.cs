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

                string[] colunas = { "@Nome", "@Senha", "@Tipo", "@Email", "@Telefone" };

                comando.Connection = conexao;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "InserirUsuario(@Nome, @Senha, @Tipo, @Email, @Telefone)";

                comando.Parameters.Add("@Nome", u.Nome);
                comando.Parameters.Add("@Senha", u.Senha);
                comando.Parameters.Add("@Tipo", u.Administrador ? "1" : "0");
                comando.Parameters.Add("@Email", u.Email);
                comando.Parameters.Add("@Telefone", u.Telefone);

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
                comando.CommandText = "AtualizarUsuario(@IdUsuario, @Nome, @Senha, @Tipo, @Email, @Telefone)";

                comando.Parameters.Add("@IdUsuario", u.IdUsuario);
                comando.Parameters.Add("@Nome", u.Nome);
                comando.Parameters.Add("@Senha", u.Senha);
                comando.Parameters.Add("@Tipo", u.Administrador ? "1" : "0");
                comando.Parameters.Add("@Email", u.Email);
                comando.Parameters.Add("@Telefone", u.Telefone);

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
                comando.CommandText = "DeletarUsuario(@IdUsuario)";

                comando.Parameters.Add("@IdUsuario", id);

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

                        u.IdUsuario = (int)reader["IdUsuario"];
                        u.Nome = (string)reader["Nome"];
                        u.Senha = (string)reader["Senha"];
                        u.Administrador = ((char)reader["Tipo"]) == '1';
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
