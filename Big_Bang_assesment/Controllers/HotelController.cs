
using Big_Bang_assesment.Models;
using Big_Bang_assesment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APIcodefirst.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotel hr;

        public HotelController(IHotel hr)
        {
            this.hr = hr;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetHotel()
        {
            try
            {
                return Ok(hr.GetHotel());
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
                var hotel = hr.GetHotelByid(id);
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
                return Ok(hr.PostHotel(hotel));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Hotel hotel)
        {
            try
            {
                hr.PutHotel(hotel);
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
                hr.DeleteHotel(id);
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
                return Ok(hr.GetLocation(location));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        /*
        [HttpGet("/filter/price")]
        public ActionResult<IEnumerable<Hotels>> GetPrice(int price)
        {
            try
            {
                return Ok(hr.GetPrice(price));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/filter/amenities")]
        public ActionResult<IEnumerable<Hotels>> GetAmenities(string amenities)
        {
            try
            {
                return Ok(hr.GetAmenities(amenities));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        */
        /*[HttpGet("/count/rooms")]
        public ActionResult<int> GetRoomAvailabilityCount(string hotelname)
        {
            try
            {
                int availablerooms = hr.GetRoomAvailabilityCount(hotelname);
                return Ok(availablerooms);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }*/
    }
}
