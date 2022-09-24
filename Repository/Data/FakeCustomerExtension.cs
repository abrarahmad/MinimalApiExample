using Bogus;
using Contract.Dtos;

namespace Repository.Data
{
    public static class FakeCustomerExtension
    {
        public static async Task GenerateCustomerAsync(this StorageContext dbContext)
        {

            var customerFaker = new Faker<CustomerDto>()
                .RuleFor(_ => _.Id, (f, u) => u.Id = f.IndexGlobal + 1)
                .RuleFor(_ => _.FirstName, (f, u) => f.Name.FirstName())                
                .RuleFor(_ => _.LastName, (f, u) => f.Name.LastName())
                .RuleFor(_ => _.Address, (f, u) => f.Address.FullAddress())
                .RuleFor(_ => _.Age, (f, u) => f.Random.Number(18,50));

            var customers = customerFaker.Generate(100);
            dbContext.Customers.AddRange(customers);
            await dbContext.SaveChangesAsync(false);
        }
    }
}
