using CQRSAPI.DataModel;
using CQRSAPI.DbSettings;
using MediatR;

namespace CQRSAPI.QueryClass
{
    public class GetEmployeeById
    {
        public class Query : IRequest<tbl_Employee> { 
        public Guid EmployeeId { get; set; }
        
        }
        public class QueryHandler : IRequestHandler<Query,tbl_Employee>
        {
            public readonly AppDbContext _dbContest;
            public QueryHandler(AppDbContext dbContest)
            {
                _dbContest = dbContest;
            }

            public async Task<tbl_Employee> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContest.tbl_Employee.FindAsync(request.EmployeeId);
            }

        }
    }
}
