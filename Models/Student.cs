namespace Student__management__system.Models
{
    public class Student
    {

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        // foreign key
        public int Id { get; set; }

        // Navigation property
        public ClassStream ClassStream { get; set; }

    }
}
