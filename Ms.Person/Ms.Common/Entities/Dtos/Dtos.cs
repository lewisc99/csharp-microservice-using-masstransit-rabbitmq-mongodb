using System;


namespace Ms.Common.Entities.Dtos
{
    public class Dtos
    {
        public record PersonDto(Guid id, string name, string doc);

        public record CreatePersonDto(string name, string doc, string email, string password);

        public record UserCreatedDto(Guid id, string email, string password);

        public record UpdatePersonDto(string name);

        public record UserUpdatedDto(Guid personId, string name);

    }
}
