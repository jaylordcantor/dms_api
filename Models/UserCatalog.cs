namespace dms_api.Models
{
    public class UserCatalog
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
    }
}