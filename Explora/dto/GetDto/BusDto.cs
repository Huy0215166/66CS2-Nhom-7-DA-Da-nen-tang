using System;
namespace Explora.dto
{
	public class BusDto
	{
        public int Id { get; set; }
        public int Id_Nha_Xe { get; set; }
        public string Name { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public DateTime Time { get; set; }
        public int Price { get; set; }
        public int Slot { get; set; }
        public int EmptySlot { get; set; }
        public int IsDelete { get; set; }
    }
}

