using DL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class ImagemDA
    {
        private String connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public void InserirImagem(Imagem i)
        {
            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                using (OracleCommand comando = new OracleCommand("InserirImagem", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                                        
                    comando.Parameters.Add("cCaminho", OracleDbType.Varchar2).Value = i.Caminho;

                    comando.ExecuteNonQuery();

                }
            }
        }

        public void AtualizarImagem(Imagem i)
        {
            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                using (OracleCommand comando = new OracleCommand("AtualizarImagem", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add("id", OracleDbType.Int32).Value = i.IdImagem;
                    comando.Parameters.Add("cCaminho", OracleDbType.Varchar2).Value = i.Caminho;

                    comando.ExecuteNonQuery();

                }

            }
        }

        public void RemoverImagem(int id)
        {
            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                using (OracleCommand comando = new OracleCommand("RemoverImagem", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("id", OracleDbType.Int32).Value = id;
                    comando.ExecuteNonQuery();
                }
            }

        }

        public List<Imagem> Listar()
        {
            List<Imagem> imagens = new List<Imagem>();

            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                string sql = "select IdImagem, Caminho from Imagens";

                using (OracleCommand comando = new OracleCommand(sql, conexao))
                {

                    comando.CommandType = System.Data.CommandType.Text;

                    using (OracleDataReader reader = comando.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Imagem i = new Imagem();
                                i.IdImagem = Convert.ToInt32(reader["IdImagem"]);
                                i.Caminho = (string)reader["Caminho"];
                            }
                        }
                    }

                    return imagens;
                }
            }
        }

        public Imagem Buscar(int id)
        {
            return Listar().FirstOrDefault(x => x.IdImagem == id);
        }
    }
}
