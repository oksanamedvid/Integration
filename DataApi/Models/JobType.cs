using DataApi.Helpers;
using DataApiDLL.Models;
using GraphQL.Types;

namespace DataApi.Models
{
    public class JobType : ObjectGraphType<JobVacancyModel>
    {
        public JobType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.Title);
            Field(x => x.VacancyUrl);
            Field(x => x.CompanyName);
            Field(x => x.Description);
        }
    }
}
