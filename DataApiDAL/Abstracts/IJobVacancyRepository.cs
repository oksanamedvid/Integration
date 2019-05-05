using System.Collections.Generic;
using DataApiDAL.Models;

namespace DataApiDAL.Abstracts
{
    public interface IJobVacancyRepository
    {
        void Add(JobVacancy job);
        JobVacancy GetById(int id);
        List<JobVacancy> Get();
    }
}
