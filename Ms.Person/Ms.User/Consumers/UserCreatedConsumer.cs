using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static Ms.User.Entities.Dtos.Dtos;

namespace Ms.User.Consumers
{
    public class UserCreatedConsumer: IConsumer<UserCreatedDto>
    {

        private readonly ILogger<UserCreatedConsumer> logger;

        public UserCreatedConsumer(ILogger<UserCreatedConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<UserCreatedDto> context)
        {

            await Console.Out.WriteLineAsync("Id: " + context.Message.Id );

            logger.LogInformation($"New User created received: " +
                $"{context.Message.Email } - {context.Message.Password}");

        }
    }
}
