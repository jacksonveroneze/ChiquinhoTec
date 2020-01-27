using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using GraphQL;
using GraphQL.Types;
using System;
using System.Linq;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema.InterviewSchema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class InterviewMutationType : ObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        // Parameters:
        //   interviewService:
        //     The interviewService param.
        //
        public InterviewMutationType(IInterviewService interviewService)
        {
            Name = "InterviewMutation";
            Description = "Interview Mutation Type";

            FieldAsync<InterviewType>(
                name: "createInterview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<InterviewInputType>> { Name = "data" }
                ),
                resolve: async context =>
                {
                    InterviewCommand data = context.GetArgument<InterviewCommand>("data");

                    Interview result = await interviewService.AddAsync(data);

                    if (interviewService.ValidationResult().IsValid is true)
                        return result;

                    context.Errors.AddRange(interviewService.ValidationResult().Errors.Select(x => new ExecutionError(x.ErrorMessage)));

                    return null;
                }
            );

            FieldAsync<BooleanGraphType>(
                name: "removeInterview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: async context =>
                {
                    Guid id = context.GetArgument<Guid>("id");

                    await interviewService.RemoveAsync(id);

                    if (interviewService.ValidationResult().IsValid is true)
                        return true;

                    context.Errors.AddRange(interviewService.ValidationResult().Errors.Select(x => new ExecutionError(x.ErrorMessage)));

                    return null;
                }
            );
        }
    }
}