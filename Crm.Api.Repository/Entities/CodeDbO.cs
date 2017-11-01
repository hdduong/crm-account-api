using System.Diagnostics.CodeAnalysis;

namespace Crm.Account.Api.Repository.Entities
{
    [ExcludeFromCodeCoverage]
    public class CodeDbO
    {
        public int CodeId { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string OrderNumber { get; set; }
    }
}
