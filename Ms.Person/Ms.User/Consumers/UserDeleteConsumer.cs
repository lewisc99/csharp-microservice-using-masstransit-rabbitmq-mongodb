
using MassTransit;
using Microsoft.Extensions.Logging;
using Ms.Common.Repositories.Contracts;
using Ms.User.Entities;
using System.Threading.Tasks;
using static Ms.Common.Entities.Dtos.Dtos;

namespace Ms.User.Consumers
{
    public class UserDeleteConsumer : IConsumer<UserDeleteDto>
    {

        private readonly ILogger<UserDeleteConsumer> logger;
        private readonly IRepository<UserEntity> _repository;


        public UserDeleteConsumer(ILogger<UserDeleteConsumer> logger, IRepository<UserEntity> repository)
        {
            this.logger = logger;
           _repository = repository;
        }

        public async Task Consume(ConsumeContext<UserDeleteDto> context)
        {

           UserEntity user =  await _repository.GetAsync(person => person.PersonId == context.Message.personId);
          _repository.RemoveAsync(user.Id);
           logger.LogInformation("User  Id to Delete: " + user.Id);
        }
    }
}
