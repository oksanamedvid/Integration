using GraphQL;
using GraphQL.Types;

namespace DataApi.Models
{
    public class NhlStatsSchema : Schema
    {
        public NhlStatsSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<NhlStatsQuery>();
            Mutation = resolver.Resolve<NhlStatsMutation>();
        }
    }
}
