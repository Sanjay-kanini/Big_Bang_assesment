﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using APIcodefirst.Repository;
using Big_Bang_assesment.Models;

namespace APIcodefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom hr;

        public RoomsController(IRoom hr)
        {
            this.hr = hr;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRoom()
        {
            try
            {
                return Ok(hr.GetRoom());
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
                var rooms = hr.GetRoomByid(id);
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
                return Ok(hr.PostRoom(room));
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
                hr.PutRoom(room);
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
                hr.DeleteRoom(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
