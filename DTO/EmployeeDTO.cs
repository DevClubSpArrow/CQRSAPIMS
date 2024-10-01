namespace CQRSAPI.DTO
{
    public class EmployeeDTO
    {
        public string? EmployeeName { get; set; }
        public string? Employeecode { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public string? Contact { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
