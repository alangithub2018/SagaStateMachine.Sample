using MassTransit;
using SagaStateMachine.Sample.Database;
using SagaStateMachine.Sample.Messages;

namespace SagaStateMachine.Sample.Handlers
{
    public class SubscribeToNewsletterHandler(AppDbContext dbContext) : IConsumer<SubscribeToNewsLetter>
    {
        public async Task Consume(ConsumeContext<SubscribeToNewsLetter> context)
        {
            var subscriber = dbContext.Subscribers.Add(new Subscriber
            {
                Id = Guid.NewGuid(),
                Email = context.Message.Email,
                SubscribedOnUtc = DateTime.UtcNow
            });

            await dbContext.SaveChangesAsync();

            await context.Publish(new SubscriberCreated 
            { 
                SubscriberId = subscriber.Entity.Id,
                Email = subscriber.Entity.Email 
            });
        }
    }
}
