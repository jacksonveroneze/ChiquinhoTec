using GraphQL.Types;

namespace ChiquinhoTec.GerenciadorContratacao.Graphql.Schema
{
    //
    // Summary:
    //     /// Class responsible for mapping schema. ///
    //
    public class QueryType : ObjectGraphType
    {
        //
        // Summary:
        //     /// Method responsible for initializing the schema. ///
        //
        public QueryType()
        {
            Name = "Query";
            //Field<CouponQueryType>("couponRootQuery", resolve: context => new { });
            //Field<ExamQueryType>("examRootQuery", resolve: context => new { });
            //Field<FidelityCardType>("fidelityCardRootQuery", resolve: context => new { });
            //Field<FranchiseeQueryType>("franchiseeCardRootQuery", resolve: context => new { });
            //Field<MedicationScheduleQueryType>("medicationScheduleRootQuery", resolve: context => new { });
            //Field<MedicationQueryType>("medicationRootQuery", resolve: context => new { });
            //Field<RecipeQueryType>("recipeRootQuery", resolve: context => new { });
            //Field<UserQueryType>("userRootQuery", resolve: context => new { });
        }
    }
}