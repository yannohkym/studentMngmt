namespace Student__management__system.Models
{
    public class Streams
    {
        public int StreamId { get; set; }
        public string StreamName { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Student> Students { get; set; }
    }
}
