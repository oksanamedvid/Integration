using System.Collections.Generic;
using System.Linq;
using DataApiDAL.Abstracts;
using DataApiDAL.Models;
using DataApiDLL.Abstracts;
using DataApiDLL.Models;

namespace DataApiDLL.Services
{
    public class JobVacancyService : IJobVacancyService
    {
        private readonly IJobVacancyRepository _repository;

        public JobVacancyService(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        public List<JobVacancyModel> GetJobVacancies()
        {
            return _repository.Get().Select(j => new JobVacancyModel
            {
                Title = j.Title,
                VacancyUrl = j.VacancyUrl,
                CompanyName = j.CompanyName,
                Description = j.Description
            }).ToList();
        }

        public void AddJobVacancy(JobVacancyModel jobModel)
        {
            var job = new JobVacancy
            {
                Title = jobModel.Title,
                VacancyUrl = jobModel.VacancyUrl,
                CompanyName = jobModel.CompanyName,
                Description = jobModel.Description
            };

            _repository.Add(job);
        }
    }
}
