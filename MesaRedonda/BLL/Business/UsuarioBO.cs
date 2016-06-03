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
        UsuarioDA usuario = new UsuarioDA();

        public int Inserir(Usuario u)
        {
            try
            {
                return usuario.Inserir(u);
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
                var usuario = this.usuario.buscar(nomeUsuario);

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
                return usuario.buscar(id);
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
                return usuario.Atualizar(u);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public int Remover(Usuario u)
        {
            try
            {
                return usuario.Remover(u.IdUsuario);
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
                return usuario.listar();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
