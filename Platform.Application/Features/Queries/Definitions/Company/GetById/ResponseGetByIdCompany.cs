using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Application.Features.Queries.Definitions.Company.GetById
{
    public class ResponseGetByIdCompany
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? WebAddress { get; set; }
        public string? TaxNo { get; set; }
        public string? TaxOffice { get; set; }
        public string? TradeRegisterNo { get; set; }
        public string? SocialSecurityNo { get; set; }
        public string? MersisNo { get; set; }
        public string? LogoPath { get; set; }
    }
}
