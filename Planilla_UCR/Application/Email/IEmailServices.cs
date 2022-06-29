namespace Application.Email
{
    public interface IEmailServices
    {
        public void SendConfirmationEmail(string message, string destiny);

        public void FiredEmployeeEmail(string employeeName, string employerName, 
                                        string projectName, string message, string destiny);
    }
}
