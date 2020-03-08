using System;
using ChiquinhoTec.GerenciadorContratacao.Common;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Domain.ValueObjects
{
    //
    // Summary:
    //     /// Classe responsável pelo value object. ///
    //
    public class Cpf : BaseValueObject
    {
        //
        // Summary:
        //     /// Médodo responsável por inicializar o value object. ///
        //
        // Parameters:
        //   value:
        //     The value param.
        //
        public Cpf(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        protected override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
