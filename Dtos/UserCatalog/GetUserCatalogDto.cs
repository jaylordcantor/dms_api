using dms_api.Dtos.Catalog;
using dms_api.Dtos.User;

namespace dms_api.Dtos.UserCatalog
{
    public class GetUserCatalogDto
    {
        public int UserId { get; set; }
        public GetUserDto User { get; set; }
        public int CatalogId { get; set; }
        public GetCatalogDto Catalog { get; set; }
    }
}