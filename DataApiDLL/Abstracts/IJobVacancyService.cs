using System.Collections.Generic;
using DataApiDLL.Models;

namespace DataApiDLL.Abstracts
{
    public interface IJobVacancyService
    {
        List<JobVacancyModel> GetJobVacancies();
        void AddJobVacancy(JobVacancyModel jobModel);
    }
}
