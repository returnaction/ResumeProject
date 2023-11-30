using AutoMapper;
using backend.Core.Context;
using backend.Core.Dtos.Condidate;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CandidateController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateResume([FromForm] CandidateCreateDto dto, IFormFile pdfFile)
        {
            // First => Save pdf to Server
            // Then = Save url into our entity

            int fiveMegaByte = 5 * 1024 * 1024;
            string pdfFileType = "application/pdf";

            if(pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfFileType)
            {
                return BadRequest("File is not valid");
            }

            string resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", resumeUrl);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }
            ///
            
            Candidate? candidate = _mapper.Map<Candidate>(dto);
            candidate.ResumeUrl = resumeUrl;
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();

            return Ok("Candidate Saved Successfully");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
        {
            List<Candidate> candidates = await _context.Candidates.Include(candidate => candidate.Job).ToListAsync();

            IEnumerable<CandidateGetDto> candidatesDto = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);

            return Ok(candidatesDto);
        }

        // Read (Download Pdf File)
        [HttpGet]
        [Route("download/{url}")]
        public IActionResult DownloadPdfFile(string url)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);
            if (!System.IO.File.Exists(filePath))
                return NotFound("File Not Found");

            byte[] pdfBytes = System.IO.File.ReadAllBytes(filePath);
            var file = File(pdfBytes, "application/pdf", url);
            return file;
        }
    }
}
