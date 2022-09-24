using Contract.Dtos;

namespace Repository.Customer
{
    public interface ICustomerRepository
    {
        Task<CustomerDto?> Get(int id);
        Task<IEnumerable<CustomerDto>> Gets();
        Task<CustomerDto> Add(CustomerDto customer);
        Task<CustomerDto> Update(CustomerDto customer);
        ValueTask<int> Delete(int id);
    }
}
