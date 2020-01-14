using System;

namespace ChiquinhoTec.GerenciadorContratacao.Common
{
    //
    // Summary:
    //     /// Interface responsável pelo contrato. ///
    //
    public interface IBaseService
    {
        // IReadOnlyCollection<Notification> Notifications { get; }

        IReadOnlyCollection<Notification> GetNotifications { get; }

        bool Invalid { get; }

        bool Valid { get; }
    }
}