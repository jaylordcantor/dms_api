using System;
using System.Collections.Generic;
using System.IO;
using dms_api.FileDirectory;
using Microsoft.Extensions.FileProviders;

namespace dms_api
{
    public static class FileMapGenerator
    {
        public static FilePath GetChild(PhysicalFileProvider provider, IFileInfo fileInfo, string parentDirectoryName)
        {
            var path = $"{parentDirectoryName}{fileInfo.Name}/";

            var newPath = new FilePath
            {
                Name = fileInfo.Name,
                ParentPath = parentDirectoryName,
            };
            if(fileInfo.IsDirectory)
            {
                newPath.Directory = true;
                newPath.FileType = ".pdf";
                newPath.Children = new List<FilePath>();

                foreach(var content in provider.GetDirectoryContents(path))
                {
                    newPath.Children.Add(GetChild(provider, content,path));
                }
            }
            return newPath;
        }
        public static FilePath  GetPaths(string rootDirectory)
        {
            if(Directory.Exists(rootDirectory) == false)
            {
                throw new ArgumentException("Directory was not found");
            }
            PhysicalFileProvider provider = new PhysicalFileProvider(rootDirectory);
            DirectoryInfo rootInfo = new DirectoryInfo(rootDirectory);

            FilePath path = new FilePath{
                Name = rootInfo.Name,
                ParentPath = "",
                Directory = true,
                FileType = ".pdf",
                Children = new List<FilePath>()
            };

            foreach(var content in provider.GetDirectoryContents(string.Empty))
            {
                path.Children.Add(GetChild(provider, content,""));
            }

            return path;
        }
    }
}