
namespace NotificationSystemDemo.Models
{
    public class EmailModel
    {
        public string SendersEmail { get; set; }
        public string ReceiversEmail { get; set; }
        public string Subject { get; set; }

        // body of email
        public string PlainTextContent { get; set; }
        public string HtmlTextContent { get; set; }
    }
}
