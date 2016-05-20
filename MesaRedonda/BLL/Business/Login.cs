using DAL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Business
{
    public class Login
    {
        public int Inserir(Login login)
        {
            try
            {
                return login.Inserir(login);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public int Atualizar(Login login)
        {
            try
            {
                return login.Atualizar(login);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public int Remover(Login login)
        {
            try
            {
                return login.Remover(login);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public int List<login> Listar()
        {
            try
            {
                return login.
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
