
namespace NotificationSystemDemo.Models
{
    public class SmsModel
    {
        public string SendersPhoneNumber { get; set; }
        public string ReceiversPhoneNumber { get; set; }
        public string Body { get; set; } // content of SMS being sent
    }
}
