using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static Ms.Common.Entities.Dtos.Dtos;

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

           await Console.Out.WriteLineAsync("Enter message (or quit to exit)");
            Console.Write("> ");

            logger.LogInformation($"New User created received: " +
                $"{context.Message.email } - {context.Message.password}");
        }
    }
}
