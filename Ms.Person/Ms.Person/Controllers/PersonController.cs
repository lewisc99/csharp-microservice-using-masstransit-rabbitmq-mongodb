using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Ms.Common.Repositories.Contracts;
using Ms.Person.Entities;
using Ms.Person.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Ms.Common.Entities.Dtos.Dtos;

namespace Ms.Person.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController:ControllerBase
    {


        private readonly IBus _bus;
        private readonly IPublishEndpoint publishEndpoint;


        private readonly IRepository<PersonEntity> repository;
        public PersonController(IRepository<PersonEntity> repository, IBus bus, IPublishEndpoint publishEndpoint)
        {
            this.repository = repository;
            _bus = bus;
            this.publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> getAllAsync()
        {

            var personsDto = (await repository.GetAllAsync()).Select(persons => persons.AsPersonDto());
            return Ok(personsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> getByIdAsync(Guid id)
        {
            var personDto = await repository.GetAsync(id);

            if (personDto == null)
            {
                return NotFound();
            }

            return Ok(personDto.AsPersonDto());
        }

        [HttpPost("")]
        public async Task<ActionResult> PostAsync(CreatePersonDto createPersonDto)
        {
            PersonEntity person = createPersonDto.AsPersonEntity();
            await repository.CreateAsync(person);
            UserCreatedDto user = new UserCreatedDto(person.Id, createPersonDto.email, createPersonDto.password);
            Uri uri = new Uri("queue:UserCreated");
            var endpoint = await _bus.GetSendEndpoint(uri);

            await endpoint.Send(user);
            return Accepted();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDto>> PutAsync(Guid id, [FromBody] UpdatePersonDto updatePersonDto)
        {

            PersonEntity person = await repository.GetAsync(id);

            if (person == null)
            {
                return NotFound();
            }
            person.Name = updatePersonDto.name;

            await repository.UpdateAsync(person);

            UserUpdatedDto userUpdatedDto = new UserUpdatedDto(person.Id, person.Name, updatePersonDto.email);
            Uri uri = new Uri("queue:UserUpdated");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(userUpdatedDto);

            PersonDto personDto = person.AsPersonDto();
            return Ok(personDto);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            PersonEntity person = await repository.GetAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            await repository.RemoveAsync(id);
            UserDeleteDto userDelete = new UserDeleteDto(id);
            Uri uri = new Uri("queue:userDelete");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(userDelete);

            return NoContent();
        }
    }
}
