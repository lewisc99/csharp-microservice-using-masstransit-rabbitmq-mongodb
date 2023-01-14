using MassTransit;
using Microsoft.Extensions.Logging;
using Ms.Common.Repositories.Contracts;
using Ms.User.Entities;
using System;
using System.Threading.Tasks;
using static Ms.Common.Entities.Dtos.Dtos;

namespace Ms.User.Consumers
{
    public class UserCreatedConsumer: IConsumer<UserCreatedDto>
    {
        private readonly ILogger<UserCreatedConsumer> logger;
        private readonly IRepository<UserEntity> _repository;

        public UserCreatedConsumer(ILogger<UserCreatedConsumer> logger, IRepository<UserEntity> repository)
        {
            this.logger = logger;
            _repository = repository;
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
