namespace SportsStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "order@example.com";

        public string MailFromAddress = "sportsstore@example.com";

        public bool UseSsl = true;

        public string Username = "MySmtUsername";

        public string Password = "MySmtPassword";

        public string ServerName = "smtp.example.com";

        public int ServerPort = 587;

        public bool WriteAsFile = false;

        public string FileLocation = @"C:\sports_store_emails";
    }
}