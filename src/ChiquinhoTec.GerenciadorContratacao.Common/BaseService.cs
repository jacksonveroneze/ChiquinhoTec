using FluentValidation.Results;
using System;

namespace ChiquinhoTec.GerenciadorContratacao.Common
{
    //
    // Summary:
    //     /// Class responsible for BaseService. ///
    //
    public abstract class BaseService : IBaseService
    {
        protected ValidationResult _validationResult = new ValidationResult();

        public ValidationResult ValidationResult()
            => _validationResult;
    }
}