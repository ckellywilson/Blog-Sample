using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ISelectRepository<BlogEntry> _repository;

        public BlogController(ISelectRepository<BlogEntry> repository)
        {
            _repository = repository;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<List<BlogEntry>>> Get()
        {
            var results = await _repository.GetAll();

            if (!results.Any())
                return NoContent();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogEntry>> Get(int id)
        {
            var result = await _repository.Get(id, t => t.BlogPosts);

            if (result == null)
                return NoContent();
            return Ok(result);
        }
    }
}