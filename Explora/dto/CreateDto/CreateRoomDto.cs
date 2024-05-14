using System;
using System.ComponentModel.DataAnnotations;

namespace Explora.dto
{
	public class CreateRoomDto
	{
        
        [Required(ErrorMessage = "ID Khách sạn không được bỏ trống ")]
        public int IdHotel { get; set; }
        [Required(ErrorMessage = "Giá không được bỏ trống ")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Số lượng còn lại không được bỏ trống ")]
        public int Slot { get; set; }
        [Required(ErrorMessage = "Loại phòng không được bỏ trống ")]
        public string TypeRoom { get; set; }
        public IFormFile ImageUrl { get; set; }
        
    }
}

