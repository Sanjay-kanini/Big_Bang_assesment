using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Big_Bang_assesment.Models;
using Big_Bang_assesment.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace Big_Bang_assesment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class RoomsController : ControllerBase
    {
        private readonly IRoom ih;

        public RoomsController(IRoom ih)
        {
            this.ih = ih;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRoom()
        {
            try
            {
                return Ok(ih.GetRoom());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Room> GetRoomByid(int id)
        {
            try
            {
                var rooms = ih.GetRoomByid(id);
                if (rooms == null)
                {
                    return NotFound();
                }
                return Ok(rooms);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Room> Post(Room room)
        {
            try
            {
                return Ok(ih.PostRoom(room));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Room room)
        {
            try
            {
                ih.PutRoom(room);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                ih.DeleteRoom(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/filter/amenities")]
        public ActionResult<IEnumerable<Room>> GetAmenities(string amenities)
        {
            try
            {
                return Ok(ih.GetAmenities(amenities));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while filtering by amenities.");
            }
        }
        [HttpGet("/filter/price")]
        public ActionResult<IEnumerable<Room>> GetPrice(int price)
        {
            try
            {
                return Ok(ih.GetPrice(price));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while filtering by price.");
            }
        }
        [HttpGet("/count/room")]
        // [Route("countarticle/{id}")]

        public int  GetCount(string room_type)
        {
            //int count = 0;
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-GPOQ94V\\SQLEXPRESS; database = Hotels;integrated security = true; trustservercertificate = true;");
            SqlCommand cmd = new SqlCommand("sp_Count", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@Room", room_type);

            int count =(int)cmd.ExecuteScalar();

            return count;
            con.Close();
        }
    }
}
