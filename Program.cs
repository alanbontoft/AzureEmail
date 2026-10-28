
using Azure;
using Azure.Communication.Email;


namespace AzureEmail;

class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "endpoint=https://comm-service-blueberry-muffin.uk.communication.azure.com/;accesskey=<your access key>";

        var emailClient = new EmailClient(connectionString);

        var emailContent = new EmailContent($"Test Email - {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}")
        {
            PlainText = "Hello from Azure Communication Services\nThis is a test email sent from the Azure Communication Services Email SDK for .NET.",
        };

        var emailMessage = new EmailMessage(
            senderAddress: "<Email Comms service MailFrom Address>",
            recipientAddress: "alan.bontoft@gmail.com",
            content: emailContent);

        EmailSendOperation operation =
            await emailClient.SendAsync(
                Azure.WaitUntil.Completed,
                emailMessage);

        Console.WriteLine($"Status: {operation.Value.Status}");
    }
}
