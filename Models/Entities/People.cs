namespace Models.Entities
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
    }
}