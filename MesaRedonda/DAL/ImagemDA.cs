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
    class ImagemDA
    {
        private String connString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
    }

    public void InserirImagem(Imagem i)
    {
        OracleConnection(connString)){

            conexao.Open();

            using (OracleCommand comando = new OracleCommand("Inserir Imagem" conexao))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

               
            }
        }
    }
}
