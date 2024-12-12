namespace CQRSAPI.Models
{
    public class JobHistory
    {
        public Guid _workHistoryId { get; set; }
        public string? _jobClass { get; set; }
        public string? _jobName { get; set; }
        public string? _actionPerformed { get; set; } = null;
        public string? _dateofAction { get; set; }
    }
}
