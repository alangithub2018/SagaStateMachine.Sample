using MassTransit;
using SagaStateMachine.Sample.Messages;

namespace SagaStateMachine.Sample.Handlers
{
    public class OnboardingCompletedHandler(ILogger<OnboardingCompletedHandler> logger) : IConsumer<OnboardingCompleted>
    {
        public Task Consume(ConsumeContext<OnboardingCompleted> context)
        {
            logger.LogInformation("Onboarding completed for {Email}", context.Message.Email);
            return Task.CompletedTask;
        }
    }
}
