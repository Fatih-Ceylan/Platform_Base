using Platform.Domain.Entities.Common;

namespace Platform.Domain.Entities.Definitions.Licence
{
    public class Licence : BaseEntity
    {
        public string? LicenseKey { get; set; }
        public string? ProductName { get; set; }
        public string? ProductVersion { get; set; }
        public string? LicenseType { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool Activated { get; set; }
        public int? MaxUsers { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        public string DBName { get; set; }
    }
}
