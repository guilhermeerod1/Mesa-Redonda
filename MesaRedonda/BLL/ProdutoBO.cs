using DAL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProdutoBO
    {

        public ProdutoBO()
        {
            ImagemBO = new ImagemBO();
        }

        public ImagemBO ImagemBO { get; set; }

        public Produto Buscar(int idProduto)
        {
            Produto p = new ProdutoDA().Buscar(idProduto);
            if (p == null)
                throw new ArgumentException("Produto não encontrado");
            return p;
        }

        public void Remover(int idProduto)
        {
            new ProdutoDA().RemoverProduto(idProduto);
        }

        public List<Produto> Listar()
        {
            List<Produto> lista = new ProdutoDA().Listar();
            if (lista == null)
                throw new ArgumentException("Erro");
            return lista;
        }

        public void Inserir(Produto p)
        {
            new ProdutoDA().InserirProduto(p);
        }

        public void Atualizar(Produto p)
        {
            new ProdutoDA().AtualizarProduto(p);
        }

    }
}
