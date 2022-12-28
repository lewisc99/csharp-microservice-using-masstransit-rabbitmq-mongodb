
using System;

namespace Ms.Person.Entities.Dtos
{
    public class Dtos
    {
        public record PersonDto(Guid id, string name, string doc);

        public record CreatePersonDto(string name, string doc, string email, string password);
    }
}
