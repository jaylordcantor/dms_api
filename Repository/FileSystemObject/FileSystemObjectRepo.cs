using System.Collections.Generic;
using dms_api.Dtos.FileSystemObject;

namespace dms_api.Repository.FileSystemObject
{
    public class FileSystemObjectRepo : IFileSystemRepo
    {
        public bool Exists(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<GetFileSystemObjectDto> SelectMany(int? id)
        {
            throw new System.NotImplementedException();
        }

        public GetFileSystemObjectDto SelectOne(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}