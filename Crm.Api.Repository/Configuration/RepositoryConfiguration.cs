using System.Diagnostics.CodeAnalysis;
using Crm.Account.Api.Repository.Interfaces;

namespace Crm.Account.Api.Repository.Configuration
{
    [ExcludeFromCodeCoverage]
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        public string MortgageReturns4Repository { get; set; }
    }
}
