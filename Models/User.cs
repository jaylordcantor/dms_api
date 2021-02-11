using System.Collections.Generic;

namespace dms_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? SectionId { get; set; }
        public Section Section { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public Role Role { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MI { get; set; }
        public string EmployeeNo { get; set; }
        public bool IsActive { get; set; }
        public List<UserCatalog> UserCatalogs { get; set; }
    }
}