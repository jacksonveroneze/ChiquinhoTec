using System;
using ChiquinhoTec.GerenciadorContratacao.Common;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.ValueObjects
{
    //
    // Summary:
    //     /// Classe responsável pelo value object. ///
    //
    public class Email : BaseValueObject
    {
        //
        // Summary:
        //     /// Médodo responsável por inicializar o value object. ///
        //
        // Parameters:
        //   value:
        //     The value param.
        //
        public Email(string value)
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
