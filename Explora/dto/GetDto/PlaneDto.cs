using System;
namespace Explora.dto
{
    public class PlaneDto
    {
        public int Id { get; set; }
        public int IdAirline { get; set; }
        public string Name { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int Price { get; set; }
        public int Slot { get; set; }
        public int EmptySlot { get; set; }
        public DateTime Time { get; set; }
        public int IsDelete { get; set; }
    }
}

