﻿namespace SagaStateMachine.Sample.Database
{
    public class Subscriber
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime SubscribedOnUtc { get; set; }
    }
}
