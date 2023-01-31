
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static Ms.Common.Entities.Dtos.Dtos;

namespace Ms.User.Consumers
{
    public class UserDeleteConsumer : IConsumer<UserDeleteDto>
    {

        private readonly ILogger<UserDeleteConsumer> logger;


        public UserDeleteConsumer(ILogger<UserDeleteConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<UserDeleteDto> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
