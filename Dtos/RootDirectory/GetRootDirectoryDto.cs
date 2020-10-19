using dms_api.Dtos.Department;

namespace dms_api.Dtos.RootDirectory
{
    public class GetRootDirectoryDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public GetDepartmentDto Department { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}