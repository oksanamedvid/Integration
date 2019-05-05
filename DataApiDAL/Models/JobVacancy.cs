using System.ComponentModel.DataAnnotations;

namespace DataApiDAL.Models
{
    public class JobVacancy
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Title { get; set; }
        public string VacancyUrl { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
    }
}
