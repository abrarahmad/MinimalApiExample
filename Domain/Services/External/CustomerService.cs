using Contract.Common;
using Contract.Dtos;
using Microsoft.Extensions.Options;
using Repository.Customer;

namespace Domain.Services.ExternalService
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly Token _tokenOption;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository, HttpClient httpClientFactory, IOptions<Token> options)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _httpClient = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _tokenOption = options.Value ?? throw new ArgumentNullException(nameof(options));

            _httpClient.BaseAddress = new Uri(_tokenOption.BaseUrl!);
        }

        public async Task<CustomerDto> Add(CustomerDto customer)
        {
            return await _customerRepository.Add(customer).ConfigureAwait(false);
        }

        public async ValueTask<int> Delete(int id)
        {
            return await _customerRepository.Delete(id).ConfigureAwait(false);
        }

        public async Task<CustomerDto?> Get(int id)
        {
            return await _customerRepository.Get(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CustomerDto>> Gets()
        {
            return await _customerRepository.Gets().ConfigureAwait(false);
        }
        public async Task<CustomerDto> Update(CustomerDto customer)
        {
            return await _customerRepository.Update(customer).ConfigureAwait(false);
        }

        private async Task<object> CallExternalService()
        {
            throw new NotImplementedException();

            ////to do query string take as param
            //var response = await
            //    _httpClient.GetAsync("customer").ConfigureAwait(false);

            //var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //if (response.IsSuccessStatusCode)
            //{
            //    return responseJson;
            //}

            //return new Exception(responseJson);

        }

    }

}
