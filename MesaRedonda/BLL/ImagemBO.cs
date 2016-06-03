using DL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web;

namespace BLL
{
    public class ImagemBO
    {

        public List<Imagem> Listar()
        {
            List<Imagem> lista = new ImagemDA().Listar();
            if (lista == null)
                throw new ArgumentException("Erro, nao foi possivel criar lista");
            return lista;
        }

        public Imagem Buscar(int id)
        {
            Imagem i = new ImagemDA().Buscar(id);
            if (i == null)
                throw new ArgumentException("Id invalido");
            return i;
        }

        public Imagem Buscar(string caminho)
        {
            Imagem i = Listar().FirstOrDefault(x => x.Caminho.Equals(caminho));
            if (i == null)
                throw new ArgumentException("Imagem com este caminho nao existe");
            return i;
        }

        public Imagem Inserir(string caminho)
        {
            Imagem i = new Imagem();
            i.Caminho = caminho;
            new ImagemDA().InserirImagem(i);
            return Buscar(i.Caminho);
        }

        public void Remover(int id)
        {
            new ImagemDA().RemoverImagem(id);
        }

        public void Atualizar(Imagem i)
        {
            new ImagemDA().AtualizarImagem(i);
        }

        public bool NomeValido(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return false;

            int tam = nome.Length;

            if (tam < 5 || tam > 245)
                return false;

            string extensao = nome.Substring(Math.Max(0, tam - 4));

            string[] extensoes = new string[] {
                ".jpg", ".png", ".bmp", "gif"
            };

            bool extensaoValida = false;

            for(int i = 0; i < extensoes.Length; ++i)
            {
                if (extensao.Equals(extensoes[i]))
                    extensaoValida = true;
            }

            if (!extensaoValida)
                return false;
            
            return true;
              
        }

        public bool imagemExistente(string caminho)
        {
            try
            {
                Buscar("~/Imagens/" + caminho);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

    }
}
