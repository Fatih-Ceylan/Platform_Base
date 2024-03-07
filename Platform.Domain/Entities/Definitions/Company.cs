﻿using Platform.Domain.Entities.Common;
using Platform.Domain.Entities.Definitions.Licence;

namespace Platform.Domain.Entities.Definitions
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string? WebAddress { get; set; }
        public string? TaxNo { get; set; }
        public string? TaxOffice { get; set; }
        public string? TradeRegisterNo { get; set; }
        public string? SocialSecurityNo { get; set; }
        public string? MersisNo { get; set; }
        public string? LogoPath { get; set; }
        public string BaseDbName { get; set; }
        public ICollection<Licence.Licence> Licence { get; set; }

    }
}
