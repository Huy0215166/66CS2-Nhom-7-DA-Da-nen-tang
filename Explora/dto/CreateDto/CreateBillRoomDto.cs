using System;
using System.ComponentModel.DataAnnotations;

namespace Explora.dto
{
	public class CreateBillRoomDto
	{
        private string _name;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        public string GuessName { get => _name; set => _name = value.Trim(); }
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string GuessEmail { get; set; }
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; } 
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Id phòng không được bỏ trống")]
        public int IdRoom { get; set; }
    }
}

