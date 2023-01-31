
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static Ms.Common.Entities.Dtos.Dtos;

namespace Ms.User.Consumers
{
    public class UserUpdateConsumer: IConsumer<UserUpdatedDto>
    {
        private readonly ILogger<UserUpdateConsumer> logger;

        public UserUpdateConsumer(ILogger<UserUpdateConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<UserUpdatedDto> context)
        {

            await Console.Out.WriteLineAsync("Enter message (or quit to exit)");

            logger.LogInformation("User updated: " + context.Message.personId + " username: " + context.Message.name + "new email: " + context.Message.email);

        }
    }
}
