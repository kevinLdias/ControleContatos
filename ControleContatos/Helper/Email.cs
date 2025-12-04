using System.Net;
using System.Net.Mail;

namespace ControleContatos.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                string host = _configuration["SmtpSettings:Host"];
                string from = _configuration["SmtpSettings:From"];
                string user = _configuration["SmtpSettings:User"];
                string password = _configuration["SmtpSettings:Password"];
                int port = _configuration.GetValue<int>("SmtpSettings:Port");
                bool enableSsl = _configuration.GetValue<bool>("SmtpSettings:EnableSsl");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(from, "Controle de Contatos")
                };

                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.EnableSsl = enableSsl;
                    smtp.Credentials = new NetworkCredential(user, password);
                    smtp.Send(mail);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao enviar e-mail: {ex.Message}", ex);
            }
        }
    }
}
