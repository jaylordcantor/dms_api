using dms_api.Dtos.FileSystemObject;

namespace dms_api.Repository.FileSystemObject
{
    public interface IFileSystemRepo : ISelectedRepo<GetFileSystemObjectDto>
    {
        bool Exists(string name);
    }
}