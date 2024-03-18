using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _RoleService;
        //private readonly IMapper _mapper;
        public RoleController(IRoleService ds)
        {
            _RoleService = ds;
            //_mapper = mapper;
        }
        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            var list = await _RoleService.GetAllAsync();
            var list1 = list/*.Select(d => _mapper.Map<ArticleDto>(d))*/;
            return Ok(list1);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _RoleService.GetRoleByIdAsync(id);
            // var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(res) : NotFound();
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Role value)
        {
            //var article = _mapper.Map<Article>(value);
            var res = await _RoleService.PostRoleAsync(value);
            //var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(value) : NotFound(value);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Role value)
        {
            // var article = _mapper.Map<Article>(value);
            var res = await _RoleService.PutRoleAsync(id, value);
            // var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(res) : NotFound(res);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _RoleService.DeleteRoleAsync(id);
            // var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(res) : NotFound(res);
        }
    }
}
