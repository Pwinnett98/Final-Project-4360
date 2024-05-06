

using System.Data;
using Azure.Communication.Email;
using FinalProject;

bool _continue = true;
User user;
GuiTier appGUI = new GuiTier();
DataTier database = new DataTier();

user = appGUI.Login();


if (database.LoginCheck(user))
{

    while (_continue)
    {
        int option = appGUI.Dashboard(user);
        string InputEmailContent = null;
        switch (option)
        {

            case 1:
                DataTable tableEmail = database.Email();
                if (tableEmail != null)
                    appGUI.DisplayEmail(tableEmail);


                string serviceConnectionString = "endpoint=https://finalprojectresource.unitedstates.communication.azure.com/;accesskey=tg1/9vMEtn/qfCQKNjYE8xQ9+aSSMR0VSwlSKBk5JVqd/5sPkJSwhTO1M6e7wfRLOsxnLdB6RyRn2E9gTVkMAQ==";
                EmailClient emailclient = new EmailClient(serviceConnectionString);
                var subject = "PACKAGE ALERT!";
                var emailContent = new Azure.Communication.Email.EmailContent(subject);

                emailContent.Html = @"
                                            <html>
                                                <body>
                                                    <h1 style=color:red>Legands Apartment Postal Services</h1>
                                                    <h4>Package Alert</h4>
                                                    <p>We have recieved your package in the office. Due to limited storage, you have 7 days to claim you rpackaged before it is returned to the post office. </p>
                                                </body>
                                            </html>";

                var sender = "donotreply@5913b1db-61ad-4b4b-8ee3-00c778c69668.azurecomm.net";

                Console.WriteLine("Please input an email address: ");
                string? InputEmail = Console.ReadLine();
                var emailClient = new EmailClient(new List<EmailClient> {
                                    new Azure.Communication.Email.EmailContent (InputEmailContent) { DisplayName = "Connecting" },
                                });

                var emailMessage = new EmailMessage(sender, emailContent, emailClient);

                try
                {
                    SendEmailResult sendEmailResult = emailClient.SendAsync(emailMessage);

                    string emailId = sendEmailResult.emailId;
                    if (!string.IsNullOrEmpty(emailId))
                    {
                        Console.WriteLine($"Email sent, EmailId = {emailId}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to send email.");
                        return;
                    }

                    var cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(2));
                    do
                    {
                        SendStatusResult sendStatus = emailContent.GetSendStatus(emailId);
                        Console.WriteLine($"Send mail status for MessageId : <{emailId}>, Status: [{sendStatus.Status}]");

                        if (sendStatus.Status != sendStatus.Queued)
                        {
                            break;
                        }
                        await Task.Delay(TimeSpan.FromSeconds(10));

                    } while (!cancellationToken.IsCancellationRequested);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine($"Email send Failure");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in sending email, {ex}");
                }
                break;


            case 2:
                DataTable TablePackageHistory = database.ShowRecords();
                if (TablePackageHistory != null)
                    appGUI.DisplayPackageHistory(TablePackageHistory);
                break;

            case 3:
                _continue = false;
                Console.WriteLine("Log out, Goodbye.");
                break;

            default:
                Console.WriteLine("Wrong Input");
                break;
        }

    }
}
else
{
    Console.WriteLine("Login Failed, Try Again.");
}

internal class SendStatusResult
{
}

internal class SendEmailResult
{
}