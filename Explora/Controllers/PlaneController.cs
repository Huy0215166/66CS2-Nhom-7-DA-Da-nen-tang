using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Explora.dto;

using System.Collections;
using System.Xml.Linq;
using Explora.data;
using Explora.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Explora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneController : Controller
    {
        private ExploraContext context;
        public PlaneController (ExploraContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreatePlane(CreatePlaneDto inputData)
        {
            
            context.TPlanes.Add(new TPlane
            {
                
                PlaneName = inputData.Name,
                IdAirline = inputData.IdAirline,
                StartPoint = inputData.Start,
                EndPoint = inputData.End,
                StartTime = inputData.Time,
                Price = inputData.Price,
                Slot = inputData.Slot,
                EmptySlot = inputData.Slot,
                IsDelete=0
            });;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Không tồn tại hãng hàng không");
            }
            
            return Ok();
            }
        [HttpGet("Get-all")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllPlane()
        {
            var plane = context.TPlanes.Select(p => new PlaneDto
            {
                Id = p.IdPlane,
                IdAirline =p.IdAirline,
                Name = p.PlaneName,
                Start = p.StartPoint,
                End = p.EndPoint,
                Time = p.StartTime,
                Price = p.Price,
                Slot = p.Slot,
                EmptySlot = p.EmptySlot

            }) ;
            return Ok(plane);
        }
        [HttpGet("Get-by-id/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetPlaneById(int id)
        {
            var plane = context.TPlanes.FirstOrDefault(p => p.IdPlane == id);
            if (plane == null)
            {
                return NotFound();
            }
            return Ok(plane);
        }
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateById(int id, UpdatePlaneDto dataUpdate)
        {
            var plane = context.TPlanes.FirstOrDefault(p => p.IdPlane == id);
            if (plane == null)
            {
                return NotFound();
            }
            plane.StartTime  = dataUpdate.Time;
            plane.Price = dataUpdate.Price;
            context.SaveChanges();
            return Ok(plane);
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteById(int id)
        {
            var plane = context.TPlanes.FirstOrDefault(p => p.IdPlane == id);
            if (plane == null)
            {
                return NotFound();
            }
            plane.IsDelete = 1;
            context.SaveChanges();
            return Ok();
        }
    }
}
