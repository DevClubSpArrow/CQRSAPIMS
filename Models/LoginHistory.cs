namespace CQRSAPI.Models
{
    public class LoginHistory
    {
        public Guid LoginId { get; set; }
        public string? _LoggedFromDevice { get; set; }
        public string? _LoggeIPAddress { get; set; }
        public DateTime _LoggeFrom { get; set; }
        public DateTime _LoggedUpto { get; set; }


    }
}
