namespace StudentMvc.Models
{
    public class AddStudentModelInput
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool Subscribe { get; set; }
    }
}
