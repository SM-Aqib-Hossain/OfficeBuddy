namespace UIPortal.Components.Models
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        // List to hold only Employee IDs
        public List<int>? EmployeeId { get; set; }
        public string? EmployeeIdsInput { get; set; }
    }
}
