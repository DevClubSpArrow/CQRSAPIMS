using CQRSAPI.DataModel;
using CQRSAPI.DbSettings;
using CQRSAPI.DTO;
using MediatR;

namespace CQRSAPI.QueryClass
{
    public class AddEmployee
    {

        public class Command:IRequest<DTO.EmployeeDTO> 
        { 
        public string? EmployeeName { get; set; }
        public string? Employeecode { get; set;}
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public string? Contact { get; set; }
        public Guid EmployeeId { get; set; }

        }

        public class CommandHandler:IRequestHandler<Command,DTO.EmployeeDTO>
        {
            private readonly AppDbContext _dbContext ;
            public CommandHandler(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<DTO.EmployeeDTO> Handle(Command request,CancellationToken cancellationToken)
            {
                var entity = new tbl_Employee
                {
                    EmployeeName = request.EmployeeName,
                    Email = request.Email,
                    EmployeeCode = request.Employeecode,
                    Designation = request.Designation,
                    Contact = request.Contact
                };
                await _dbContext.tbl_Employee.AddAsync(entity,cancellationToken); 
                await _dbContext.SaveChangesAsync(cancellationToken);
                EmployeeDTO dto = new EmployeeDTO();
                dto.EmployeeName = request.EmployeeName;
                dto.Employeecode=request.Employeecode;
                dto.EmployeeId = request.EmployeeId;
                dto.Email = request.Email;
                dto.Contact = request.Contact;
                return dto;
               
            }
        }
    }
}
