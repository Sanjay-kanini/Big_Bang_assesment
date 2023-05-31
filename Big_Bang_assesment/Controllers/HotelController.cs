
using Big_Bang_assesment.Models;
using Big_Bang_assesment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Big_Bang_assesment.Controllers
{
    [Authorize(Roles ="Guest")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotel ih;

        public HotelController(IHotel ih)
        {
            this.ih= ih;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetHotel()
        {
            try
            {
                return Ok(ih.GetHotel());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> Getid(int id)
        {
            try
            {
                var hotel = ih.GetHotelByid(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Hotel> Post(Hotel hotel)
        {
            try
            {
                return Ok(ih.PostHotel(hotel));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Hotel hotel)
        {
            try
            {
                ih.PutHotel(hotel);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ih.DeleteHotel(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/filter/location")]
        public ActionResult<IEnumerable<Hotel>> GetLocation(string location)
        {
            try
            {
                return Ok(ih.GetLocation(location));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
       
    }
}
