using Contract.Dtos;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace Repository.Customer
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly StorageContext _dbContext;
        public CustomerRepository(StorageContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<CustomerDto> Add(CustomerDto customer)
        {
            var addItem = _dbContext.Add(customer);
            addItem.State = EntityState.Added;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return addItem.Entity;
        }

        public async ValueTask<int> Delete(int id)
        {

            var item = await _dbContext.Customers.FindAsync(id).ConfigureAwait(false);
            if (item is null)
                throw new Exception($"Not found id={id}");

            _dbContext.Remove(item);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return id;
        }

        public async Task<CustomerDto?> Get(int id)
        {
            var item = await _dbContext.Customers.FindAsync(id).ConfigureAwait(false);
            if (item is null)
                throw new Exception($"Not found id={id}");
            return item;
        }

        public async Task<IEnumerable<CustomerDto>> Gets()
        {
            return await _dbContext.Customers.ToListAsync().ConfigureAwait(false);
        }

        public async Task<CustomerDto> Update(CustomerDto customer)
        {
            var addItem = _dbContext.Customers.Add(customer);
            addItem.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return addItem.Entity;
        }
    }
}
