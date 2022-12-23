using Microsoft.AspNetCore.Mvc;
using Ms.Common.Repositories.Contracts;
using Ms.Person.Entities;
using Ms.Person.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Ms.Person.Entities.Dtos.Dtos;

namespace Ms.Person.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController:ControllerBase
    {


        private readonly IRepository<PersonEntity> repository;
        public PersonController(IRepository<PersonEntity> repository)
        {
            this.repository = repository;
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

            return Accepted();

        }
    }
}
