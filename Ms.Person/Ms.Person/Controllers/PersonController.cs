using Microsoft.AspNetCore.Mvc;


namespace Ms.Person.Controllers
{

    [ApiController]
    [Route("[controller]/api")]
    public class PersonController:ControllerBase
    {


        [HttpGet]
        public ActionResult<string> get()
        {
            return Ok("person1");
        }
    }
}
