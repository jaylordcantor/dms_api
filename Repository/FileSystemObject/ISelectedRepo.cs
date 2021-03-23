using System.Collections.Generic;

namespace dms_api.Repository.FileSystemObject
{
    public interface ISelectedRepo<TModel>
    {
        TModel SelectOne(int? id);
        List<TModel> SelectMany(int? id);
    }
}