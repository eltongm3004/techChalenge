using ApiLoja.Core.Entities;
using ApiLoja.Core.Requests;

namespace ApiLoja.Core.Interfaces
{
    public interface IProdutoRepository
    {
        void AddProduto(CriarProdutoRequest produto);
        void UpdateProduto(UpdateProdutoRequest produto);
        void DeleteProduto(int id);
        List<Produto> GetAllProdutos();
        List<Produto> GetProdutosByCategoria(string categoria);

    }
}
