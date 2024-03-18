using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        private readonly IEmployeeService _EmployeeService;
        //private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService ds)
        {
            _EmployeeService = ds;
            //_mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var list = await _EmployeeService.GetAllAsync();
            var list1 = list/*.Select(d => _mapper.Map<ArticleDto>(d))*/;
            return Ok(list1);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _EmployeeService.GetEmployeeByIdAsync(id);
           // var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(res) : NotFound();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employee value)
        {
            //var article = _mapper.Map<Article>(value);
            var res = await _EmployeeService.PostEmployeeAsync(value);
            //var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(value) : NotFound(value);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Employee value)
        {
           // var article = _mapper.Map<Article>(value);
            var res = await _EmployeeService.PutEmployeeAsync(id, value);
           // var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(res) : NotFound(res);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _EmployeeService.DeleteEmployeeAsync(id);
           // var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(res) : NotFound(res);
        }
    }
}
