using Crm.Account.Api.Repository.Entities;

namespace Crm.Account.Api.Repository.Interfaces
{
    public interface ILosRepository
    {
        LosDbO GetLosById(int losId);
    }
}