namespace Student__management__system.Models
{
    public class ClassStream
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Student> Students { get; set; }
    }
}
