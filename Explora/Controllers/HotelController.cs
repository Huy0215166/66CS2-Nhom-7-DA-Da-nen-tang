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



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Explora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private ExploraContext context;
        public HotelController(ExploraContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpPost("Create")]
        [Authorize(Roles = "HotelOwner")]
        public IActionResult CreateHotel(CreateHotelDto inputData)
        {
            var HotelOwnerId = Int32.Parse(User.FindFirst("Id")?.Value ?? "0");
            context.THotels.Add(new THotel
            {
                HotelName = inputData.HotelName,
                Email = inputData.Email,
                AddressHotel = inputData.AddressHotel,
                PhoneNumber = inputData.PhoneNumber,
                UserId = HotelOwnerId,
                IsDelete = 0
            }); 
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Không tồn tại");
            }
            return Ok();
        }
        [HttpGet("Get-all")]
        public IActionResult GetAllHotel()
        {
            var hotel = context.THotels.Select(h => new HotelDto
            {
                IdHotel = h.IdHotel,
                HotelName = h.HotelName,
                AddressHotel = h.AddressHotel,
                PhoneNumber = h.PhoneNumber,
                UserId = h.UserId,
                Email = h.Email,
                IsDelete = h.IsDelete
            });
            return Ok(hotel);
        }
        [HttpGet("Get-by-id/{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = context.THotels.FirstOrDefault(h => h.IdHotel == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }
        [HttpGet("Get-by-id-hotel-owner")]
        [Authorize(Roles = "HotelOwner")]
        public IActionResult GetByIdUser()
        {
            var HotelOwner = Int32.Parse(User.FindFirst("Id")?.Value ?? "0");
            var hotel = context.THotels.Where(b => b.UserId == HotelOwner).ToList();
            if (hotel == null)
            {
                return NotFound();
            }
            var hotels = hotel.Select(h => new HotelDto
            {
                IdHotel = h.IdHotel,
                HotelName = h.HotelName,
                AddressHotel = h.AddressHotel,
                PhoneNumber = h.PhoneNumber,
                UserId = h.UserId,
                Email = h.Email,
                IsDelete = h.IsDelete

            });
            return Ok(hotels);
        }
        [HttpPut("Update/{id}")]
        public IActionResult UpdateById(int id, UpdateHotelDto dataUpdate)
        {
            var hotel = context.THotels.FirstOrDefault(r => r.IdHotel == id);
            if (hotel == null)
            {
                return NotFound();
            }
            hotel.Email = dataUpdate.Email;
            hotel.AddressHotel = dataUpdate.AddressHotel;
            hotel.PhoneNumber = dataUpdate.PhoneNumber;
            context.SaveChanges();
            return Ok(hotel);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            var hotel = context.THotels.FirstOrDefault(r => r.IdHotel == id);
            if (hotel == null)
            {
                return NotFound();
            }
            hotel.IsDelete = 1;
            context.SaveChanges();
            return Ok();
        }
    }
}
