using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Explora.dto;
using Explora.data;
using Explora.Entity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Explora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderRoomController : ControllerBase
    {
        private ExploraContext context;
        public OrderRoomController(ExploraContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpPost("CreateBillRoom")]
        [Authorize(Roles = "User")]
        public IActionResult CreateOrder([FromBody] CreateBillRoomDto dataInput)
        {
            var room = context.TRooms.FirstOrDefault(p => p.IdRoom == dataInput.IdRoom);
            if (room == null)
            {
                return NotFound("Không có phòng này");
            }
            if (room.EmptySlot == 0)
            {
                return BadRequest("Đã hết phòng");
            }

            var order = context.TBillRooms.Add(new TBillRoom
            {
                GuessName = dataInput.GuessName,
                GuessEmail = dataInput.GuessEmail,
                PhoneNumber = dataInput.PhoneNumber,
                StartTime = dataInput.StartTime,
                EndTime = dataInput.EndTime,
                TotalPrice = room.Price * (int)((dataInput.EndTime - dataInput.StartTime).TotalDays),
                BuyTime = DateTime.Now.Date,
                IdRoom = dataInput.IdRoom,
                UserId = Int32.Parse(User.FindFirst("Id")?.Value ?? "0")
            });
            room.EmptySlot--;
            context.SaveChanges();
            return Ok();
        }
        [HttpGet("Get-all")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllCreateOrder()
        {
            var room = context.TBillRooms.Select(r => new BillRoomDto
            {
                BillId = r.BillId,
                GuessName = r.GuessName,
                GuessEmail = r.GuessEmail,
                PhoneNumber = r.PhoneNumber,
                TotalPrice = r.TotalPrice,
                BuyTime = r.BuyTime,
                IdRoom = r.IdRoom,
                UserId = r.UserId
            });
            return Ok(room);
        }
        [HttpGet("Get-by-id-user")]
        [Authorize(Roles = "User")]
        public IActionResult GetByIdUser()
        {
            var UserId = Int32.Parse(User.FindFirst("Id")?.Value ?? "0");
            var bill = context.TBillRooms.Where(b => b.UserId == UserId).ToList();
            if (bill == null)
            {
                return NotFound();
            }
            var billroom = bill.Select(r => new BillRoomDto
            {
                BillId = r.BillId,
                GuessName = r.GuessName,
                GuessEmail = r.GuessEmail,
                PhoneNumber = r.PhoneNumber,
                TotalPrice = r.TotalPrice,
                BuyTime = r.BuyTime,
                IdRoom = r.IdRoom,
                UserId = r.UserId
            });
            return Ok(billroom);
        }
        [HttpPost("Check-out")]
        [Authorize(Roles = "HotelOwner")]
        public IActionResult CheckOut([FromBody] CreateBillRoomDto dataInput)
        {
            var room = context.TRooms.FirstOrDefault(p => p.IdRoom == dataInput.IdRoom);
            room.EmptySlot++;
            context.SaveChanges();
            return Ok();
        }
        [HttpGet("Get-by-id-Hotel/{id}")]
        [Authorize(Roles = "HotelOwner")]
        public IActionResult GetByHotel(int id)
        {
            var userId = Int32.Parse(User.FindFirst("Id")?.Value ?? "0");
            var hotel = context.THotels.FirstOrDefault(h => h.IdHotel == id);
            if (hotel == null)
            {
                return NotFound();
            }
            if(userId != hotel.UserId)
            {
                return Forbid("Không phải khách sạn của bạn");
            }
            var bill = context.TBillRooms.Include(b => b.IdRoomNavigation).Where(b => b.IdRoomNavigation.IdHotel == id).ToList();
            var billroom = bill.Select(r => new BillRoomDto
            {
                BillId = r.BillId,
                GuessName = r.GuessName,
                GuessEmail = r.GuessEmail,
                PhoneNumber = r.PhoneNumber,
                TotalPrice = r.TotalPrice,
                BuyTime = r.BuyTime,
                IdRoom = r.IdRoom,
                UserId = r.UserId
            });
            return Ok(billroom);
        }
    }
}
