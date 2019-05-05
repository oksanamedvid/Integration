using GraphQL.Types;

namespace DataApi.Models
{
    public class JobInputType : InputObjectGraphType
    {
        public JobInputType()
        {
            Name = "JobInput";
            Field<StringGraphType>("title");
            Field<StringGraphType>("vacancyUrl");
            Field<StringGraphType>("companyName");
            Field<StringGraphType>("description");
        }
    }
}
