using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IInterviewRepository : IBaseRepository<Interview> 
    {
        Task<List<Interview>> FindInterviewsByPersonId(Guid personId);

        bool HasInterviewsByPersonId(Guid personId);
    }
}