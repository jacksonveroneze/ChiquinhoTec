using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using FluentValidation;

namespace ChiquinhoTec.GerenciadorContratacao.Services.Validators
{
    //
    // Summary:
    //     /// Class responsible for the validator. ///
    //
    public class PersonValidator : AbstractValidator<PersonCommand>
    {
        //
        // Summary:
        //     /// Method responsible for initializing the validator. ///
        //
        // Parameters:
        //   personRepository:
        //     The personRepository param.
        //
        public PersonValidator(IPersonRepository personRepository)
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(async (x, c) =>
                {
                    Person person = await personRepository.FindPersonByEmailAsync(x);

                    return person is null;
                }).WithMessage("E-mail já encontra-se cadastrado.");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .Must(ValidCpf).WithMessage("CPF inválido.")
                .MustAsync(async (x, c) =>
               {
                   Person person = await personRepository.FindPersonByCpfAsync(x);

                   return person is null;
               }).WithMessage("CPF já encontra-se cadastrado.");
        }

        //
        // Summary:
        //     /// Method responsible for validate CPF. ///
        //
        // Parameters:
        //   number:
        //     The number param.
        //
        public static bool ValidCpf(string number)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;

            int soma;
            int resto;

            number = number.Trim();
            number = number.Replace(".", "").Replace("-", "");

            if (number.Length != 11)
            {
                return false;
            }
            tempCpf = number.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1[i]);
            }
            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            int soma2 = 0;

            for (int i = 0; i < 10; i++)
            {
                soma2 += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma2 % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();
            return number.EndsWith(digito);
        }
    }
}