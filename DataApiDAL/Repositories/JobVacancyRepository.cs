using System.Collections.Generic;
using System.Linq;
using DataApiDAL.Abstracts;
using DataApiDAL.Models;

namespace DataApiDAL.Repositories
{
    public class JobVacancyRepository : IJobVacancyRepository
    {
        private readonly JobContext _dbContext;

        public JobVacancyRepository(JobContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(JobVacancy job)
        {
            _dbContext.JobVacancies.Add(job);
            _dbContext.SaveChanges();
        }

        public JobVacancy GetById(int id)
        {
            return _dbContext.JobVacancies.FirstOrDefault(j => j.Id == id);
        }

        public List<JobVacancy> Get()
        {
            return _dbContext.JobVacancies.ToList();
        }
    }
}
