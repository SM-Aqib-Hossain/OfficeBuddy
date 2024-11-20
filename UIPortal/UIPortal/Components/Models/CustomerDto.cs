namespace UIPortal.Components.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Password { get; set; }

        public string? Role { get; set; }
        public int Balance { get; set; } = 0;
    }

}
