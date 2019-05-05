using DataApiDLL.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DataApi.Helpers
{
    public class ContextServiceLocator
    {
        public IJobVacancyService JobVacancyService => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IJobVacancyService>();

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
