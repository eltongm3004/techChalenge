using ApiLoja.Core.Requests;
using FluentValidation;

namespace ApiLoja.Adapters.Validation
{
    public partial class CriarProdutoRequestValidator : AbstractValidator<CriarProdutoRequest>
    {
        public CriarProdutoRequestValidator()
        {
            RuleFor(x => x.Preco)
               .NotEmpty().WithMessage("Preço é obrigatório.");
            RuleFor(x => x.Nome)
                .Must(HaveValue).WithMessage("Nome é obrigatório.");
            RuleFor(x => x.Categoria)
                .Must(HaveValue).WithMessage("Categoria é obrigatório.");
        }

        private bool HaveValue(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
