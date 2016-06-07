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
        private ProdutoDA dao;
        public ImagemBO ImagemBO { get; set; }        

        public ProdutoBO()
        {
            ImagemBO = new ImagemBO();
            dao = new ProdutoDA();
        }        

        public Produto Buscar(int idProduto)
        {
            Produto p = dao.Buscar(idProduto);
            if (p == null)
                throw new ArgumentException("Produto não encontrado");
            return p;
        }

        public void Remover(int idProduto)
        {
            dao.RemoverProduto(idProduto);
        }

        public List<Produto> Listar()
        {
            return dao.Listar();
        }

        public void Inserir(Produto p)
        {
            dao.InserirProduto(p);
        }

        public void Atualizar(Produto p)
        {
            dao.AtualizarProduto(p);
        }

    }
}
