using CQRSAPI.DataModel;
using CQRSAPI.QueryClass;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<IEnumerable<tbl_Employee>> GetEmployee() => await _mediator.Send(new GetEmployee.Query());

        [HttpGet("{Id}")]
        public async Task<tbl_Employee> GetEmployeeById(Guid Id)=> await _mediator.Send(new GetEmployeeById.Query());

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] AddEmployee.Command command)
        {
          var result=  await _mediator.Send(command);
          return CreatedAtAction(nameof(AddEmployee),new { EmployeeId = result.EmployeeId,EmployeeName=result.EmployeeName },null);
        }
    }
}
