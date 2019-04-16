namespace Tiktack.WebGraphQL.DataLayer.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public bool AllowedSmoking { get; set; }
    }
}