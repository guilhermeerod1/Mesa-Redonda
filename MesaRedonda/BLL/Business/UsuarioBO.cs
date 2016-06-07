using DAL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Business
{
    public class UsuarioBO
    {
        UsuarioDA dao = new UsuarioDA();

        public int Inserir(Usuario u)
        {
            try
            {
                return dao.Inserir(u);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public bool Submeter(string nomeUsuario, string senha)
        {
            try
            {
                var usuario = this.dao.buscar(nomeUsuario);

                if(usuario == null)
                    return false;

                if (!usuario.Senha.Trim().Equals(senha))
                    return false;

                return true;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Buscar(int id)
        {
            try
            {
                return dao.buscar(id);
            }

            catch (Exception)
            {
                return null;
            }
        }

        public int Atualizar(Usuario u)
        {
            try
            {
                return dao.Atualizar(u);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public int Remover(int id)
        {
            try
            {
                return dao.Remover(id);
            }

            catch (Exception)
            {
                throw;
            }
        }



        public List<Usuario> Listar()
        {
            try
            {
                return dao.listar();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
