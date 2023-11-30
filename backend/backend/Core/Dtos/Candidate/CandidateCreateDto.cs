namespace backend.Core.Dtos.Condidate
{
    public class CandidateCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }

        //nav

        public long JobId { get; set; }
    }
}
