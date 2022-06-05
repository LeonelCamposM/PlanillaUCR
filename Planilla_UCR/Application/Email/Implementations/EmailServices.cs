namespace Application.Email.Implementations
{
    public class EmailServices : IEmailServices
    {
        private EmailSender _emailSender = new EmailSender();
        public void SendConfirmationEmail(string message, string destiny)
        {
            string htmlContent = "<section>" + "<div>" + "<center>" + "<FONT SIZE=4 COLOR=#00695c>" + "<strong>" + "Planilla_UCR" +
                    "</strong>" + "</FONT>" + "</center>" + "<br>" + "</br>" + "</div>" + "<div>" + "<center>" + "¡Ya casi! " +
                    "</center>" + "<br>" + "</br>" + "</div>" + "<div>" + "<center>" + "¡Gracias por registrarte en Planilla_UCR! " +
                    "</center>" +
                    "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + "<center>" + "<strong>" + message +
                    "</strong>" + "</center>" + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" +
                    "Recibiste este email porque te registraste en una cuenta de Planilla_UCR con esta dirección de email. " +
                    "Si piensas que fue un error, por favor, ignora este email. No te preocupes la cuenta aún no ha sido creada." +
                    "</div>" + "<div>" + "<FONT COLOR=#00695c>" + "Planilla_UCR" + "</FONT>" + "<br>" + "</br>" + "</div>" + "</section>";
            string subject = "Confirmación de registro Planilla_UCR";
            _emailSender.SendMail(destiny, subject, htmlContent);
        }
    }
}
