using backend.Core.Enums;

namespace backend.Core.Entities
{
    public class Company : BaseEntitty
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }

        //nav

        public ICollection<Job> Jobs { get; set; }

    }
}
