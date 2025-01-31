using MassTransit;

namespace SagaStateMachine.Sample.Sagas
{
    public class NewsletterOnboardingSagaData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }

        // Which one is the current state of the saga when saving the data?
        public string CurrentState { get; set; }

        // Adding supported properties for the saga
        public Guid SubscriberId { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool WelcomeEmailSent { get; set; }
        public bool FollowUpEmailSent { get; set; }
        public bool OnboardingCompleted { get; set; }
    }
}
