using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSAPI.DataModel
{
    public class tbl_Employee
    {
        [Key]
        public Guid EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeCode { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public string? Contact { get; set; }

    }
}
