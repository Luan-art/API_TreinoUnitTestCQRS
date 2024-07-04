using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Commands.v1.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        private const int MinimumAge = 18;
        private const int MinimumNameLength = 5;
        private const int MinimumDocLength = 11;
        private readonly Regex _onlyNumbers = new(@"[^\d]", RegexOptions.Compiled, TimeSpan.FromMilliseconds(1));

        public CreatePersonCommandValidator()
        {
            RuleFor(createPersonCommand => createPersonCommand.Birthday)
                .Must(createPersonCommand => DateTime.Now.Year - createPersonCommand.Year >= MinimumAge)
                .WithMessage("Idade deve ser maior que 18 anos!"); // TODO colocar essas mensagens em constantes para poder fazer validação no teste

            RuleFor(createPersonCommand => createPersonCommand.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
                .MinimumLength(MinimumNameLength)
                .WithMessage($"O campo {{PropertyName}} deve conter mais que {MinimumNameLength} caracteres!");

            RuleFor(createPersonCommand => createPersonCommand.CPF)
                       .Cascade(CascadeMode.Stop)
                       .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!")
                       .Must(BeValidCPF)
                       .WithMessage("O campo {PropertyName} deve conter um CPF válido!");
        }

        private bool BeValidCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = _onlyNumbers.Replace(cpf, string.Empty);

            if (cpf.Length != MinimumDocLength)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            var tempCpf = cpf.Substring(0, 9);
            var sum = 0;

            for (var i = 0; i < 9; i++)
                sum += (tempCpf[i] - '0') * (10 - i);

            var remainder = sum % 11;
            var firstVerifierDigit = remainder < 2 ? 0 : 11 - remainder;

            tempCpf += firstVerifierDigit;
            sum = 0;

            for (var i = 0; i < 10; i++)
                sum += (tempCpf[i] - '0') * (11 - i);

            remainder = sum % 11;
            var secondVerifierDigit = remainder < 2 ? 0 : 11 - remainder;

            return cpf.EndsWith($"{firstVerifierDigit}{secondVerifierDigit}");
        }
    }
}
