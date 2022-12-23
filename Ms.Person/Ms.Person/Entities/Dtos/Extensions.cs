
using static Ms.Person.Entities.Dtos.Dtos;

namespace Ms.Person.Entities.Dtos
{
    public static class Extensions
    {

        public static PersonDto AsPersonDto(this PersonEntity person)
        {
            return new PersonDto(person.id, person.Name, person.Doc);
        }


        public static PersonEntity AsPersonEntity(this CreatePersonDto person)
        {
            return new PersonEntity() { Doc = person.doc, Name = person.name};
        }
    }
}
