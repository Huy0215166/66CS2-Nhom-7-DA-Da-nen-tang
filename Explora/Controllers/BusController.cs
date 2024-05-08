using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Explora.dto;
using Explora.data;
using Explora.Entity;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Explora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : Controller
    {
        private ExploraContext context;
        public BusController(ExploraContext context)
        {
            this.context = context;
        }
        [HttpPost("Create")]
        public IActionResult CreateBus(CreateBusDto inputData)
        {
            context.TBus.Add(new TBu
            {
                
                BusName = inputData.Name,
                IdNhaXe = inputData.IdNhaXe,
                StartPoint = inputData.Start,
                EndPoint = inputData.End,
                StartTime = inputData.Time,
                Price = inputData.Price,
                Slot = inputData.Slot,
                EmptySlot = inputData.Slot,
                IsDelete= 0
            });
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest(new { message = "Không tồn tại nhà xe" });
            }
            return Ok();
        }
        [HttpGet("Get-all")]
        public IActionResult GetAllBus()
        {
            var bus = context.TBus.Select(b => new BusDto
            {
                Id = b.IdBus,
                Id_Nha_Xe = b.IdNhaXe,
                Name = b.BusName,
                Start = b.StartPoint,
                End = b.EndPoint,
                Time = b.StartTime,
                Price = b.Price,
                Slot = b.Slot,
                EmptySlot = b.EmptySlot,
                IsDelete =b.IsDelete
            });
            return Ok(new { bus });
        }
        [HttpGet("Get-by-id/{id}")]
        public IActionResult GetBusById(int id)
        {
            var bus = context.TBus.FirstOrDefault(b => b.IdBus == id);
            if (bus == null)
            {
                return NotFound();
            }
            return Ok(new { bus });
        }
        [HttpPut("Update/{id}")]
        public IActionResult UpdateById(int id,UpdateBusDto dataUpdate)
        {
            var bus = context.TBus.FirstOrDefault(b => b.IdBus == id);
            if (bus == null)
            {
                return NotFound();
            }
            bus.StartTime = dataUpdate.Time;
            bus.Price = dataUpdate.Price;
            context.SaveChanges();
            return Ok(new { bus });
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            var bus = context.TBus.FirstOrDefault(b => b.IdBus == id);
            if(bus == null)
            {
                return NotFound();
            }
            bus.IsDelete = 1;
            context.SaveChanges();
            return Ok();
        }
    }
}

