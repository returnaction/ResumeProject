namespace backend.Core.Dtos.Condidate
{
    public class CandidateGetDto
    {
        public long ID { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }

        public long JobId { get; set; }
        public string JobTitle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        //nav

        
    }
}
