using ApiLoja.Core.Entities;
using ApiLoja.Core.Interfaces;
using ApiLoja.Core.Requests;

namespace ApiLoja.Core.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void CriarProduto(CriarProdutoRequest produto)
        {
            _produtoRepository.AddProduto(produto);
        }

        public void EditarProduto(UpdateProdutoRequest produto)
        {
            _produtoRepository.UpdateProduto(produto);
        }

        public void RemoverProduto(int id)
        {
            _produtoRepository.DeleteProduto(id);
        }

        public List<Produto> GetAllProdutos()
        {
            return _produtoRepository.GetAllProdutos();
        }

        public List<Produto> BuscarProdutosPorCategoria(string categoria)
        {
            return _produtoRepository.GetProdutosByCategoria(categoria);
        }
    }
}
