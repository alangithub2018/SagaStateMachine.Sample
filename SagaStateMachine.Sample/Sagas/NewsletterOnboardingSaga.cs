using MassTransit;
using SagaStateMachine.Sample.Messages;

namespace SagaStateMachine.Sample.Sagas
{
    public class NewsletterOnboardingSaga : MassTransitStateMachine<NewsletterOnboardingSagaData>
    {
        // Define the states of the saga and the events that can trigger transitions
        public State Welcoming { get; set; }
        public State FollowingUp { get; set; }
        public State Onboarding { get; set; }

        public Event<SubscriberCreated> SubscriberCreated { get; set; }
        public Event<WelcomeEmailSent> WelcomeEmailSent { get; set; }
        public Event<FollowUpEmailSent> FollowUpEmailSent { get; set; }

        public NewsletterOnboardingSaga()
        {
            InstanceState(x => x.CurrentState);

            Event(() => SubscriberCreated, x => x.CorrelateById(context => context.Message.SubscriberId));
            Event(() => WelcomeEmailSent, x => x.CorrelateById(context => context.Message.SubscriberId));
            Event(() => FollowUpEmailSent, x => x.CorrelateById(context => context.Message.SubscriberId));

            // Implement the state transitions
            Initially(
                // What should happend when the event SubscriberCreated is received?
                When(SubscriberCreated)
                    .Then(context =>
                    {
                        context.Saga.SubscriberId = context.Message.SubscriberId;
                        context.Saga.Email = context.Message.Email;
                    })
                    .TransitionTo(Welcoming)
                    .Publish(context => new SendWelcomeEmail(context.Message.SubscriberId, context.Message.Email))
                );

            // We are no longer in the initial state, so we need to define what would we like to happen next
            During(Welcoming,
                When(WelcomeEmailSent)
                    .Then(context => context.Saga.WelcomeEmailSent = true)
                    .TransitionTo(FollowingUp)
                    .Publish(context => new SendFollowUpEmail(context.Message.SubscriberId, context.Message.Email))
                );

            During(FollowingUp,
                When(FollowUpEmailSent)
                    .Then(context => context.Saga.FollowUpEmailSent = true)
                    .TransitionTo(Onboarding)
                    .Publish(context => new OnboardingCompleted 
                    { 
                        SubscriberId = context.Message.SubscriberId,
                        Email = context.Message.Email 
                    })
                // Mark the end of the saga
                .Finalize()
                );
        }
    }
}
