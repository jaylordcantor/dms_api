using dms_api.Dtos.Department;
using dms_api.Dtos.Division;
using dms_api.Dtos.Location;
using dms_api.Dtos.Section;
using dms_api.Models;

namespace dms_api.Dtos.User
{
    public class UserRegisterDto
    {
        public int? DivisionId { get; set; }
        public GetDivisionDto Division { get; set; }
        public int DepartmentId { get; set; }
        public GetDepartmentDto Department { get; set; }
        public int? SectionId { get; set; }
        public GetSectionDto Section { get; set; }
        public int LocationId { get; set; }
        public GetLocationDto Location { get; set; }
        public Role Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MI { get; set; }
        public string EmployeeNo { get; set; }
        public bool IsActive { get; set; }
    }
}