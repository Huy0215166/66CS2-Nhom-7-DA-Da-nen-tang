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

    public class AirlineController : Controller
    {
        private ExploraContext context;
        public AirlineController(ExploraContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateAirline(CreateAirlineDto inputData)
        {

            context.TAirlines.Add(new TAirline
            {
                AirlineName=inputData.AirlineName,
                Email = inputData.Email,
                AddressAirline= inputData.AddressAirline,
                PhoneNumber=inputData.PhoneNumber,
                IsDelete = 0
            });
            context.SaveChanges();
            return Ok();

        }

        [HttpGet("Get-all")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllAirline()
        {
            var airline= context.TAirlines.Select(a => new AirlineDto
            {
                IdAirline = a.IdAirline,
                AirlineName = a.AirlineName,
                Email = a.Email,
                AddressAirline = a.AddressAirline,
                PhoneNumber = a.PhoneNumber,
                IsDelete = a.IsDelete

            });
            return Ok(airline);
        }
        [HttpGet("Get-by-id/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAirlineById(int id)
        {
            var airline = context.TAirlines.FirstOrDefault(a => a.IdAirline == id);
            if (airline == null)
            {
                return NotFound();
            }
            return Ok(airline);
        }
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateById(int id, UpdateAirlineDto dataUpdate)
        {
            var airline = context.TAirlines.FirstOrDefault(a => a.IdAirline == id);
            if (airline == null)
            {
                return NotFound();
            }
            airline.Email = dataUpdate.Email;
            airline.AddressAirline = dataUpdate.AddressAirline;
            airline.PhoneNumber = dataUpdate.PhoneNumber;
            context.SaveChanges();
            return Ok(airline);
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteById(int id)
        {
            var airline = context.TAirlines.FirstOrDefault(a => a.IdAirline == id);
            if (airline == null)
            {
                return NotFound();
            }
            airline.IsDelete = 1;
            context.SaveChanges();
            return Ok();
        }
    }
}
