using Persistence;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Activities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : BaseApiController
    {

        

        [HttpGet]
        public async Task<ActionResult<List<Activity>>>GetActivities(){
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>>GetActivity(Guid id){
            return await Mediator.Send(new Details.Query{Id=id});
        }

        [HttpPost]
        public async Task<IActionResult>CreateActivity(Activity activity){
            return Ok(await Mediator.Send(new Create.Command{newActivity=activity}));
        }
        [HttpPut]
        public async Task<IActionResult>EditActivity(Activity activity){
            return Ok(await Mediator.Send(new Edit.Command{updatedActivity=activity}));
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult>DelteActivity(Guid Id){
            return Ok(await Mediator.Send(new Delete.Command{Id=Id}));
        }


       
    }
}