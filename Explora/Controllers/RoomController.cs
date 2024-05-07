using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Explora.dto;
using Explora.data;
using Explora.Entity;
using System.Collections;
using System.Xml.Linq;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Explora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private ExploraContext context;
        public RoomController(ExploraContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpPost("Create")]
        [Authorize(Roles = "HotelOwner")]
        public IActionResult CreateRoom(CreateRoomDto inputData)
        {
            context.TRooms.Add(new TRoom
            { 
                
                IdHotel = inputData.IdHotel,
                Price = inputData.Price,
                Slot = inputData.Slot,
                EmptySlot = inputData.Slot,
                TypeRoom = inputData.Type,
                ImageUrl = inputData.Image_Url,
                IsDelete=0
            });;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Không tồn tại khách sạn");
            }
            return Ok();
        }
        [HttpGet("Get-all")]
        public IActionResult GetAllRoom()
        {
            var room = context.TRooms.Select(r => new RoomDto
            {
                IdRoom = r.IdRoom,  
                IdHotel=r.IdHotel,
                Price = r.Price,
                Slot = r.Slot,
                EmptySlot = r.EmptySlot,
                TypeRoom = r.TypeRoom,
                ImageUrl = r.ImageUrl,
                IsDelete = r.IsDelete
            });
            return Ok(room);
        }
        [HttpGet("Get-by-id/{id}")]
        [Authorize(Roles = "HotelOwner")]
        public IActionResult GetRoomById(int id)
        {
            var room = context.TRooms.FirstOrDefault(r => r.IdRoom == id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }
        [HttpGet("Get-all-room-by-hotel/{hotelId}")]
        [Authorize(Roles = "HotelOwner")]
        public IActionResult GetAllRoomByHotel(int hotelId)
        {
            var userId = Int32.Parse(User.FindFirst("Id")?.Value ?? "0");
            var hotel = context.THotels.FirstOrDefault(h => h.IdHotel == hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            if (userId != hotel.UserId)
            {
                return Forbid("Không phải khách sạn của bạn");
            }
            var room = context.TRooms.Where(r => r.IdHotel == hotelId).Select(r => new RoomDto
            {
                IdRoom = r.IdRoom,
                IdHotel = r.IdHotel,
                Price = r.Price,
                Slot = r.Slot,
                EmptySlot = r.EmptySlot,
                TypeRoom = r.TypeRoom,
                ImageUrl = r.ImageUrl,
                IsDelete = r.IsDelete
            });
            return Ok(room);


        }
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "HotelOwner")]
        public IActionResult UpdateById(int id, UpdateRoomDto dataUpdate)
        {
            var room = context.TRooms.FirstOrDefault(r => r.IdRoom == id);
            if (room == null)
            {
                return NotFound();
            }
           
            room.Price = dataUpdate.Price;
            
            room.ImageUrl = dataUpdate.Image_Url;
            context.SaveChanges();
            return Ok(room);
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "HotelOwner")]
        public IActionResult DeleteById(int id)
        {
            var room = context.TRooms.FirstOrDefault(r => r.IdRoom == id);
            if (room == null)
            {
                return NotFound();
            }
            room.IsDelete = 1;
            context.SaveChanges();
            return Ok();
        }
    }
}
