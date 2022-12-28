
using System;

namespace Ms.User.Entities.Dtos
{
    public class Dtos
    {
        public record UserCreatedDto(Guid Id, string Email, string Password);


    }
}
