using DL;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProdutoDA
    {

        private String connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public void InserirProduto(Produto p)
        {
            
            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                using (OracleCommand comando = new OracleCommand("InserirProduto", conexao))
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add("cnome", OracleDbType.Varchar2).Value = p.Nome;
                    comando.Parameters.Add("cpreco", OracleDbType.Varchar2).Value = p.Preco;
                    comando.Parameters.Add("cdescricao", OracleDbType.Clob).Value = p.Descricao;
                    if(p.Imagem != null)
                    comando.Parameters.Add("cIdImagem", OracleDbType.Int32).Value = p.Imagem.IdImagem;
                    else
                        comando.Parameters.Add("cIdImagem", OracleDbType.Int32).Value = null;

                    comando.ExecuteNonQuery();

                }

            }

        }

        public void AtualizarProduto(Produto p)
        {

            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                using (OracleCommand comando = new OracleCommand("AtualizarProduto", conexao))
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add("id", OracleDbType.Int32).Value = p.IdProduto;
                    comando.Parameters.Add("cnome", OracleDbType.Varchar2).Value = p.Nome;
                    comando.Parameters.Add("cpreco", OracleDbType.Varchar2).Value = p.Preco;
                    comando.Parameters.Add("cdescricao", OracleDbType.Clob).Value = p.Descricao;
                    if (p.Imagem != null)
                        comando.Parameters.Add("cIdImagem", OracleDbType.Int32).Value = p.Imagem.IdImagem;
                    else
                        comando.Parameters.Add("cIdImagem", OracleDbType.Int32).Value = null;

                    comando.ExecuteNonQuery();

                }

            }

        }

        public void RemoverProduto(int id)
        {

            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                using (OracleCommand comando = new OracleCommand("RemoverProduto", conexao))
                {

                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add("id", OracleDbType.Int32).Value = id;

                    comando.ExecuteNonQuery();

                }

            }

        }

        public List<Produto> Listar()
        {

            List<Produto> produtos = new List<Produto>();

            using (OracleConnection conexao = new OracleConnection(connString))
            {

                conexao.Open();

                string sql = "select IdProduto, Nome, Preco, Descricao, IdImagem from Produtos";

                using (OracleCommand comando = new OracleCommand(sql, conexao))
                {

                    comando.CommandType = System.Data.CommandType.Text;
                    
                    using(OracleDataReader reader = comando.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                Produto p = new Produto();
                                p.IdProduto = Convert.ToInt32(reader["IdProduto"]);
                                p.Nome = (string)reader["Nome"];
                                p.Preco = Convert.ToDecimal(reader["Preco"]);                              
                                p.Descricao = reader.GetOracleClob(reader.GetOrdinal("Descricao")).Value;
                                string idI = reader["idImagem"].ToString();
                                if (!string.IsNullOrEmpty(idI))
                                {
                                    int idImagem = Convert.ToInt32(idI);
                                    p.Imagem = new ImagemDA().Buscar(idImagem);
                                }

                                produtos.Add(p);
                            }
                        }
                    }

                    return produtos;

                }

            }

        }

        public Produto Buscar(int id)
        {
            return Listar().FirstOrDefault(x => x.IdProduto == id);
        }

    }
}
