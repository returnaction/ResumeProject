using AutoMapper;
using backend.Core.Context;
using backend.Core.Dtos.Company;
using backend.Core.Dtos.Job;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public JobController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto newJobDto)
        {
            Job? newJob = _mapper.Map<Job>(newJobDto);

            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();

            return Ok("Job Created Successfuly");

        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
        {
            List<Job> jobs = await _context.Jobs.Include(job => job.Company).ToListAsync();

            IEnumerable<JobGetDto> jobsDto = _mapper.Map<IEnumerable<JobGetDto>>(jobs);

            return Ok(jobsDto);

        }
    }
}
