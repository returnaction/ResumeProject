using backend.Core.Enums;

namespace backend.Core.Entities
{
    public class Job : BaseEntitty
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }

        // nav

        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }
}
