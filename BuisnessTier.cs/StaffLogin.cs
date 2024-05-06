using Google.Protobuf.WellKnownTypes;

namespace FinalProject;
class User{

    public string UserID {get;set;} =string.Empty;
    public string UserPassword {get;set;} = string.Empty;
}

class EmailContent{
    private string subject;

    public EmailContent(string subject)
    {
        this.subject = subject;
    }

    public string MessageId {get;set;} = string.Empty;  
    public string EmailClient {get;set;} = string.Empty;
    public string DisplayName {get;set;} = string.Empty; 
    public string EmailMessage {get;set;} = string.Empty; 
    public string InputEmailContent {get;set;} = string.Empty;
    public string SendEmailResult {get;set;} = string.Empty;
    public string Html { get; set; } = string.Empty;
    public string GetSendStatus {get;set;} = string.Empty;
    public string SendStatus {get;set;} = string.Empty;
}