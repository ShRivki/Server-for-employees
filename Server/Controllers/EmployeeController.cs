using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.API.models;
using Solid.Core.DTOs;
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
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService ds, IMapper mapper)
        {
            _EmployeeService = ds;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {
            var list = await _EmployeeService.GetAllAsync();
            var list1 = list.Select(d=> _mapper.Map<EmployeeDto>(d));
            return Ok(list1);
        }
        [HttpGet("name={name}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get(string name)
        {  
            var list = await _EmployeeService.GetAllAsync();

            if (name == null)
            {
               return Ok(list);
            }
            var list1 = list.Select(d => _mapper.Map<EmployeeDto>(d));
            return Ok(list.Where(x=>x.FirstName.Contains(name)||x.LastName.Contains( name)||x.Identity.Contains(name) ||x.DateOfBirth.ToString().Contains(name)));

        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _EmployeeService.GetEmployeeByIdAsync(id);
           // var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(res) : NotFound();
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Get(LogIn user)
        {
            var list = await _EmployeeService.GetAllAsync();
            Employee foundEmployee = null;

            foreach (var employee in list)
            {
                if (employee.Password == user.Password && (user.Name.Equals(employee.FirstName)|| user.Name.Equals(employee.LastName) ))
                {
                    foundEmployee = employee;
                    break;
                }
            }
            return foundEmployee != null ? Ok(foundEmployee): NotFound("שם משתמש או סיסמא שגוי");
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel value)
        {
            var Employee= _mapper.Map<Employee>(value);
            var res = await _EmployeeService.PostEmployeeAsync(Employee);
            var resDto = _mapper.Map<EmployeeDto>(res);
            return res != null ? Ok(resDto) : NotFound(resDto);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel value)
        {
            var e = _mapper.Map<Employee>(value);
            var res = await _EmployeeService.PutEmployeeAsync(id, e);
            var resDto = _mapper.Map<EmployeeDto>(res);
            return res != null ? Ok(resDto) : NotFound(resDto);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _EmployeeService.DeleteEmployeeAsync(id);
            var resDto = _mapper.Map<EmployeeDto>(res);
            return res != null ? Ok(resDto) : NotFound(resDto);
        }
    }
}
