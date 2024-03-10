namespace StudentMvc.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public bool Subscribe { get; set; }
    }

}
