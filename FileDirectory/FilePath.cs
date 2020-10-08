using System.Collections.Generic;

namespace dms_api.FileDirectory
{
    public struct FilePath
    {
        public string Name { get; set; }
        public string ParentPath { get; set; }
        public bool Directory { get; set; }
        public string FileType { get; set; }
        public List<FilePath> Children { get; set; }
    }
}