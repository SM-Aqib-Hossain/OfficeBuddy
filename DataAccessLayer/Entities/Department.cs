    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DataAccessLayer.Entities
    {
        public class Department
        {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        // List to hold only Employee IDs
        public List<int>? EmployeeId { get; set; }
    }
    }
