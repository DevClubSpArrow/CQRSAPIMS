
using CQRSAPI.DataModel;
using CQRSAPI.DbSettings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CQRSAPI.QueryClass
{
    public class GetEmployee
    {
        public class Query : IRequest<IEnumerable<tbl_Employee>> { }
        public class QueryHandler : IRequestHandler<Query, IEnumerable<tbl_Employee>>
        {
            public readonly AppDbContext _dbContest;
            public QueryHandler(AppDbContext dbContest)
            {
                _dbContest = dbContest;
            }

            public async Task<IEnumerable<tbl_Employee>> Handle(Query request, CancellationToken cancellationToken)
            {
               return await _dbContest.tbl_Employee.ToListAsync(cancellationToken);
            }

        }

    }
}
