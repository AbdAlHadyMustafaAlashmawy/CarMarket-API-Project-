using Day1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext context;

        public CarController(AppDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult ShowAllCars()
        {
            var Cars = context.Cars;
            return Ok(Cars);
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult ShowCarById(int id)
        {
            var car = context.Cars.Where(x => x.Id == id);
            return Ok(car);
        }
        [HttpGet]
        [Route("{name:alpha}")]
        public ActionResult ShowCarByName(string name)
        {
            var car = context.Cars.Where(x => x.Name == name);
            return Ok(name);
        }
        [HttpPost(Name ="AddingCarInDb")]
        public ActionResult AddCar(Car car)
        {
            if (ModelState.IsValid)
            {
            context.Cars.Add(car);
            context.SaveChanges();
            return Created(Url.Action("AddingCarInDb", new { id = car.Id }) + car.Id, car);}
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public ActionResult UpdateCarDetails([FromRoute]int id,[FromBody]Car car)
        {
            if (ModelState.IsValid)
            {
            var OldCar= context.Cars.FirstOrDefault(x=>x.Id==id);
                if(OldCar == null)
                {
                    return BadRequest("No record id like that");
                }
               
                OldCar.Name = car.Name;
                OldCar.Model = car.Model;
                OldCar.Color = car.Color;
                OldCar.price = car.price;
            context.SaveChanges();
            return StatusCode(204, "Data saved but No Content in Response");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult RemoveCarById(int id)
        {
            try
            {
            var car=context.Cars.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                context.Cars.Remove(car);
                context.SaveChanges();
                return StatusCode(204, "Record Removed Successfully");
            }
            return BadRequest("There is no Record with this id");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
