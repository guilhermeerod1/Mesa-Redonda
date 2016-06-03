using DAL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicoBO
    {
        public ServicoBO()
        {
            ImagemBO = new ImagemBO();
        }

        public ImagemBO ImagemBO { get; set; }

        public Servico Buscar(int idServico)
        {
            Servico p = new ServicoDA().Buscar(idServico);
            if (p == null)
                throw new ArgumentException("Servico não encontrado");
            return p;
        }

        public void Remover(int idServico)
        {
            new ServicoDA().RemoverServico(idServico);
        }

        public List<Servico> Listar()
        {
            List<Servico> lista = new ServicoDA().Listar();
            if (lista == null)
                throw new ArgumentException("Erro");
            return lista;
        }

        public void Inserir(Servico p)
        {
            new ServicoDA().InserirServico(p);
        }

        public void Atualizar(Servico p)
        {
            new ServicoDA().AtualizarServico(p);
        }
    }
}
