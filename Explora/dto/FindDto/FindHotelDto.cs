using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Explora.dto.FindDto
{
    public class FindHotelDto
    {
        [Required]
        private string _address;
        [FromQuery(Name = "AddressHotel")]
        public string AddressHotel { get => _address; set => _address = value.Trim(); }

    }
}

