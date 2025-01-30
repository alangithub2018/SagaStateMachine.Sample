namespace SagaStateMachine.Sample.Emails
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string email);
        Task SendFollowUpEmailAsync(string email);
    }
}
