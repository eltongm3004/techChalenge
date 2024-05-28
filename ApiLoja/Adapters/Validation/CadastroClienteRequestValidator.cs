using ApiLoja.Core.Responses;
using FluentValidation;

namespace ApiLoja.Adapters.Validation
{
    public partial class CadastroClienteRequestValidator : AbstractValidator<CadastroClienteRequest>
    {
        public CadastroClienteRequestValidator()
        {
            RuleFor(x => x.Endereco.CEP)
                .NotEmpty().WithMessage("CEP é obrigatório.")
                .Matches(@"^\d{8}$").WithMessage("CEP inválido. Use 12345678.")
                .MaximumLength(8).WithMessage("Máximo de 8 caracteres.");
            RuleFor(x => x.CPF)
                .Must(HaveValue)
                .WithMessage("CPF deve ser preenchido.")
                .Must(IsValidCPF)
                .WithMessage("CPF Inválido.")
                .Matches("^[0-9]+$")
                .Length(11)
                .WithMessage("CPF deve conter 11 dígitos.");
            RuleFor(x => x.Senha)
               .NotEmpty().WithMessage("Senha é obrigatória.")
               .MinimumLength(8).WithMessage("Senha deve ter pelo menos 8 caracteres.")
               .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$")
               .WithMessage("Senha deve ter pelo menos 8 caracteres, incluindo 1 letra maiúscula, 3 números, e 2 caracteres especiais.");
        }

        private bool IsValidCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return false;
            }

            // Remove non-numeric characters from CPF
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Check if CPF has 11 digits
            if (cpf.Length != 11)
            {
                return false;
            }

            // Check if all digits are the same (e.g., 111.111.111-11)
            if (cpf.All(d => d == cpf[0]))
            {
                return false;
            }

            // Validate CPF using the algorithm
            int[] numbers = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += numbers[i] * (10 - i);
            }

            int remainder = sum % 11;

            int expectedDigit1 = remainder < 2 ? 0 : 11 - remainder;

            if (numbers[9] != expectedDigit1)
            {
                return false;
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += numbers[i] * (11 - i);
            }

            remainder = sum % 11;

            int expectedDigit2 = remainder < 2 ? 0 : 11 - remainder;

            return numbers[10] == expectedDigit2;
        }
        private bool HaveValue(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
