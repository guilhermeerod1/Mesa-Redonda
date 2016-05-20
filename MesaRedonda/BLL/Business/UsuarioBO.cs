using DAL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Business
{
    class UsuarioBO
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
                {
                    return false;
                }

                if (!usuario.Senha.Trim().Equals(senha))
                {
                    return false;
                }
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
                return UsuarioDA.Buscar(id);
            }

            catch (Exception) { 
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
                return UsuarioDA.Remover(u);
            }

            catch (Exception)
            {
                throw;
            }
        }



        public static int List<Usuario> Listar()
        {
            try
            {
                return Usuario.Listar();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
