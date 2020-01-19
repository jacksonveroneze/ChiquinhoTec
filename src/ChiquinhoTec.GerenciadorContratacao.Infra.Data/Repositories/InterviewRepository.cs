using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Enums;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Repositories
{
    //
    // Summary:
    //     /// Class responsible for the repository. ///
    //
    public class InterviewRepository : BaseRepository<Interview>, IInterviewRepository
    {
        //
        // Summary:
        //     /// Method responsible for initializing the repository. ///
        //
        // Parameters:
        //   context:
        //     The context param.
        //
        public InterviewRepository(ApplicationDbContext context) : base(context) { }

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public Task<List<Interview>> FindInterviewsByPersonId(Guid personId)
        {
            return _context
                        .Set<Interview>()
                        .Where(x => x.Person.Id == personId && x.IsActive == true)
                        .AsNoTracking()
                        .ToListAsync();
        }

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public Task<Interview> FindInterviewCurrentYearByPersonIdAndSquad(Guid personId, Squads squadId)
        {
            return _context
                        .Set<Interview>()
                        .Where(x => x.Person.Id == personId &&
                                    x.Squad.Equals(squadId) &&
                                    x.SchedulingDate.Year == DateTime.Now.Year &&
                                    x.IsActive == true)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
        }

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public bool HasInterviewsByPersonId(Guid personId)
        {
            int total = _context
                            .Set<Interview>()
                            .Where(x => x.Person.Id == personId && x.IsActive == true)
                            .Count();

            return total > 0;
        }

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        public Task<List<Interview>> FindByFilterAsync(InterviewFilterCommand command)
        {
            return _context.Set<Interview>()
                  .Select(p => p)
                  .Where(p => p.SchedulingDate.Equals(command.SchedulingDate) ||
                                     p.Squad.Equals(command.Squad) ||
                                     EF.Functions.ILike(p.Person.Name, @$"%{command.PersonName}%") ||
                                     EF.Functions.ILike(p.Person.Email.Value, @$"%{command.Email}%") ||
                                     p.Person.Cpf.Value == command.PersonCpf
                               )
                  .AsNoTracking()
                  .ToListAsync();
        }

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   personId:
        //     The personId param.
        //
        //   date
        //     The date param.
        //
        public Task<Interview> FindInterviewByPersonIdAndDate(Guid personId, DateTime date)
        {
            DateTime dateSub3Hours = date;
            dateSub3Hours = dateSub3Hours.AddHours(-3);

            DateTime dateAdd3Hours = date;
            dateAdd3Hours = dateAdd3Hours.AddHours(3);

            return _context
                        .Set<Interview>()
                        .Where(x => x.Person.Id == personId &&
                                    (x.SchedulingDate.Date.Equals(date.Date)) &&
                                    (x.SchedulingDate > dateSub3Hours && x.SchedulingDate < dateAdd3Hours) &&
                                    x.IsActive == true)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
        }

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   squadId:
        //     The squadId param.
        //
        //   date:
        //     The date param.
        //
        public Task<Interview> FindInterviewBySquadAndDate(Squads squadId, DateTime date)
        {
            DateTime dateSub3Hours = date;
            dateSub3Hours = dateSub3Hours.AddHours(-3);

            DateTime dateAdd3Hours = date;
            dateAdd3Hours = dateAdd3Hours.AddHours(3);

            return _context
                        .Set<Interview>()
                        .Where(x => x.Squad.Equals(squadId) &&
                                    (x.SchedulingDate.Date >= dateSub3Hours && x.SchedulingDate.Date <= dateAdd3Hours) &&
                                    x.IsActive == true)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
        }
    }
}