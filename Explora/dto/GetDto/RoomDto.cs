using System;
namespace Explora.dto
{
	public class RoomDto
	{
        public int IdRoom { get; set; }

        public int IdHotel { get; set; }

        public int Slot { get; set; }
        public int EmptySlot { get; set; }

        public int Price { get; set; }

        public string TypeRoom { get; set; } 

        public string ImageUrl { get; set; } 

        public int IsDelete { get; set; }
    }
}

