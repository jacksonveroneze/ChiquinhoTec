using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using GraphQL.Types;
using System;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.InterviewSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class InterviewQueryType : ObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        // Parameters:
        //   interviewRepository:
        //     The interviewRepository param.
        //
        public InterviewQueryType(IInterviewRepository interviewRepository)
        {
            Name = "InterviewQuery";
            Description = "Interview Query Type";

            Field<ListGraphType<InterviewType>>(
                name: "allInterviews",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "skip" },
                    new QueryArgument<IntGraphType> { Name = "take" }
                ),
                resolve: context => interviewRepository.FindAllAsync());

            Field<InterviewType>(
                name: "interview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context => interviewRepository.FindAsync(context.GetArgument<Guid>("id")));
        }
    }
}