﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Explora.dto;
using Explora.data;
using Explora.Entity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Explora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPlaneController : Controller
    {
        private ExploraContext context;
        public OrderPlaneController(ExploraContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult CreateOrder([FromBody] CreateOrderPlaneDto dataInput)
        {
            var plane = context.TPlanes.FirstOrDefault(p => p.IdPlane == dataInput.IdPlane);
            if(plane == null)
            {
                return NotFound(new { message = "Không có chuyến bay này" });
            }
            if(plane.EmptySlot < dataInput.Amount)
            {
                return BadRequest(new { message = "Chuyến bay không còn đủ chỗ" });
            }
            List<TPlaneTicket> tickets = new List<TPlaneTicket>();
            foreach(var ticket in dataInput.createPlaneTicketDtos)
            {
                tickets.Add(new TPlaneTicket
                {
                    GuessName = ticket.GuessName,
                    GuessEmail = ticket.GuessEmail,
                    PhoneNumber = ticket.PhoneNumber,
                    DateOfBirth = ticket.DateOfBirth,
                    Nationality = ticket.Nationality,
                    PasspostNumber = ticket.PasspostNumber,
                    ExpiredTime = ticket.ExpiredTime,
                    IdPlane = dataInput.IdPlane
                });
                plane.EmptySlot--;
            }
            
            var order = context.TOrderPlanes.Add(new TOrderPlane
            {
                TPlaneTickets = tickets,
                Amount = dataInput.Amount,
                TotalPrice = plane.Price * dataInput.Amount,
                BuyTime = DateTime.Now,
                IdPlane = dataInput.IdPlane,
                UserId = Int32.Parse(User.FindFirst("Id")?.Value ?? "0")
            });
            context.SaveChanges();
            return Ok(new { order });
        }
        [HttpGet("Get-all")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllCreateOrder()
        {
            var plane = context.TOrderPlanes.Include(p => p.TPlaneTickets).Include(p => p.User).Select(p => new OrderPlaneDto
            {
                OrderId = p.OrderId,
                Amount = p.Amount,
                TotalPrice = p.TotalPrice,
                BuyTime = p.BuyTime,
                IdPlane = p.IdPlane,
                UserId = p.UserId,
                TPlaneTickets = p.TPlaneTickets,
                User = p.User
            });
            return Ok(new { plane });
        }
        [HttpGet("Get-by-id-user")]
        [Authorize(Roles = "User")]
        public IActionResult GetByIdUser()
        {
            var UserId = Int32.Parse(User.FindFirst("Id")?.Value ?? "0");

            var bill = context.TOrderPlanes.Include(p => p.TPlaneTickets).Include(p => p.User).Where(p => p.UserId == UserId).ToList();
            if (bill == null)
            {
                return NotFound();
            }
            var billplane = bill.Select(p => new OrderPlaneDto
            {
                OrderId = p.OrderId,
                Amount = p.Amount,
                TotalPrice = p.TotalPrice,
                BuyTime = p.BuyTime,
                IdPlane = p.IdPlane,
                UserId = p.UserId,
                TPlaneTickets = p.TPlaneTickets,

            });
            return Ok(new { billplane });
        }

    }
}

