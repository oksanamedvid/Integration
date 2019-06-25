using System;
using System.Collections.Generic;
using System.Linq;
using DataApiDAL.Abstracts;
using DataApiDAL.Models;
using DataApiDLL.Abstracts;
using DataApiDLL.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DataApiDLL.Services
{
    public class JobVacancyService : IJobVacancyService
    {
        private readonly IJobVacancyRepository _repository;
        private readonly IDistributedCache _distributedCache;
        private const string CacheKey = "Jobs";

        public JobVacancyService(IJobVacancyRepository repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }

        public List<JobVacancyModel> GetJobVacancies()
        {
            var existingJobs = _distributedCache.GetString(CacheKey);
            if (!string.IsNullOrEmpty(existingJobs))
            {
                return JsonConvert.DeserializeObject<List<JobVacancyModel>>(existingJobs);
            }

            var jobs = _repository
                .Get()
                .Select(j => new JobVacancyModel
                {
                    Title = j.Title ?? String.Empty,
                    VacancyUrl = j.VacancyUrl ?? String.Empty,
                    CompanyName = j.CompanyName ?? String.Empty,
                    Description = j.Description ?? String.Empty
                })
                .ToList();

            var jsonJobs = JsonConvert.SerializeObject(jobs);
            _distributedCache.SetString(CacheKey, jsonJobs, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });

            return jobs;
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
