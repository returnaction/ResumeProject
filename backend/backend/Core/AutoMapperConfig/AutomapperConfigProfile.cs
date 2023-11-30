using AutoMapper;
using backend.Core.Dtos.Company;
using backend.Core.Dtos.Condidate;
using backend.Core.Dtos.Job;
using backend.Core.Entities;

namespace backend.Core.AutoMapperConfig
{
    public class AutomapperConfigProfile : Profile
    {
        public AutomapperConfigProfile()
        {
            // Company
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyGetDto>();

            // Jobs
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            // Candicates
            CreateMap<CandidateCreateDto, Candidate>();
            CreateMap<Candidate, CandidateGetDto>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Title));
                
        }
    }
}
