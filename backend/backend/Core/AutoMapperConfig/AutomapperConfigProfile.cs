using AutoMapper;
using backend.Core.Dtos.Company;
using backend.Core.Entities;

namespace backend.Core.AutoMapperConfig
{
    public class AutomapperConfigProfile : Profile
    {
        public AutomapperConfigProfile()
        {
            // Company
            CreateMap<CompanyCreateDto, Company>();


            // Jobs

            // Candicates
        }
    }
}
