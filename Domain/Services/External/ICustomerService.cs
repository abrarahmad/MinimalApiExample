using Contract.Dtos;

namespace Domain.Services.ExternalService
{
    public interface ICustomerService
    {
        Task<CustomerDto?> Get(int id);
        Task<IEnumerable<CustomerDto>> Gets();
        Task<CustomerDto> Add(CustomerDto customer);
        Task<CustomerDto> Update(CustomerDto customer);
        ValueTask<int> Delete(int id);
    }
}
