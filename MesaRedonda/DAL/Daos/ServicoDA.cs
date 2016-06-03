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
    public class ServicoDA
    {
        private String connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public void InserirServico(Servico s)
        {

            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                using (OracleCommand comando = new OracleCommand("InserirServico", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add("cnome", OracleDbType.Varchar2).Value = s.Nome;
                    comando.Parameters.Add("cpreco", OracleDbType.Decimal).Value = s.Preco;
                    comando.Parameters.Add("cdescricao", OracleDbType.Clob).Value = s.Descricao;
                    if (s.Imagem != null)
                        comando.Parameters.Add("cIdImagem", OracleDbType.Int32).Value = s.Imagem.IdImagem;
                    else
                        comando.Parameters.Add("cIdImagem", OracleDbType.Int32).Value = null;

                    comando.ExecuteNonQuery();

                }
            }
        }

        public void AtualizarServico(Servico s)
        {

            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                using (OracleCommand comando = new OracleCommand("AtualizarServico", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add("id", OracleDbType.Int32).Value = s.IdServico;
                    comando.Parameters.Add("cnome", OracleDbType.Varchar2).Value = s.Nome;
                    comando.Parameters.Add("cpreco", OracleDbType.Decimal).Value = s.Preco;
                    comando.Parameters.Add("cdescricao", OracleDbType.Clob).Value = s.Descricao;
                    if (s.Imagem != null)
                        comando.Parameters.Add("cIdImagem", OracleDbType.Int32).Value = s.Imagem.IdImagem;
                    else
                        comando.Parameters.Add("cIdImagem", OracleDbType.Int32).Value = null;
                    comando.ExecuteNonQuery();

                }

            }

        }

        public void RemoverServico(int id)
        {

            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                using (OracleCommand comando = new OracleCommand("RemoverServico", conexao))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add("id", OracleDbType.Int32).Value = id;

                    comando.ExecuteNonQuery();

                }
            }

        }

        public List<Servico> Listar()
        {

            List<Servico> servicos = new List<Servico>();

            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                string sql = "select IdServico, Nome, Preco, Descricao, IdImagem from Servicos";

                using (OracleCommand comando = new OracleCommand(sql, conexao))
                {

                    comando.CommandType = System.Data.CommandType.Text;

                    using (OracleDataReader reader = comando.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Servico s = new Servico();

                                s.IdServico = Convert.ToInt32(reader["IdServico"]);
                                s.Nome = (string)reader["Nome"];
                                s.Preco = Convert.ToDecimal(reader["Preco"]);
                                s.Descricao = reader.GetOracleClob(reader.GetOrdinal("Descricao")).Value;
                                string idI = reader["idImagem"].ToString();
                                if (!string.IsNullOrEmpty(idI))
                                {
                                    int idImagem = Convert.ToInt32(idI);
                                    s.Imagem = new ImagemDA().Buscar(idImagem);
                                }

                                servicos.Add(s);

                            }
                        }
                        return servicos;
                    }                    
                }
            }
            
        }

        public Servico Buscar(int id)
        {
            return Listar().FirstOrDefault(x => x.IdServico == id);
        }

    }
}
