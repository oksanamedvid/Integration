using DataApi.Helpers;
using GraphQL.Types;

namespace DataApi.Models
{
    public class NhlStatsQuery : ObjectGraphType
    {
        public NhlStatsQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<ListGraphType<JobType>>(
                "jobs",
                resolve: context => contextServiceLocator.JobVacancyService.GetJobVacancies());
        }
    }
}
