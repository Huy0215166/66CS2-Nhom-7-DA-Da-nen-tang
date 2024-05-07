using System;
namespace Explora.dto
{
	public class UpdateUserDto
	{
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public string UrlAvatar { get; set; }
    }
}

