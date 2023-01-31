
using MassTransit;
using Microsoft.Extensions.Logging;
using Ms.Common.Repositories.Contracts;
using Ms.User.Entities;
using System;
using System.Threading.Tasks;
using static Ms.Common.Entities.Dtos.Dtos;

namespace Ms.User.Consumers
{
    public class UserUpdateConsumer: IConsumer<UserUpdatedDto>
    {
        private readonly ILogger<UserUpdateConsumer> logger;
        private readonly IRepository<UserEntity> _repository;

        public UserUpdateConsumer(ILogger<UserUpdateConsumer> logger, IRepository<UserEntity> repository)
        {
            this.logger = logger;
            this._repository = repository;
        }

        public async Task Consume(ConsumeContext<UserUpdatedDto> context)
        {

            UserEntity userEntity = await  _repository.GetAsync( s => s.PersonId == context.Message.personId);

            userEntity.Email = context.Message.email;
            logger.LogInformation("User updated: " + userEntity.Id + " username: " + context.Message.name + "new email: " + context.Message.email);
            _repository.UpdateAsync(userEntity);

        }
    }
}
