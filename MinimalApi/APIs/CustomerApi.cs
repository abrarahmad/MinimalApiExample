using Contract.Dtos;
using Domain.Services.ExternalService;

namespace MinimalApi.APIs
{
    public static class CustomerApi
    {
        public static void RegisterCustomerApi(this WebApplication app)
        {
            app.MapGet("/customer/gets", async (ICustomerService customerService) =>
            {
                return await customerService.Gets().ConfigureAwait(false);

            }).WithName("Customer").WithTags("External-Services")
             .Produces(400).Produces(200).Produces(404).Produces(500);

            app.MapGet("/customer/get", async (ICustomerService customerService, int id) =>
            {
                var response = await customerService.Get(id).ConfigureAwait(false);
                return response;

            }).WithName("GetExternal-Servicess").WithTags("External-Services")
             .Produces(400).Produces(200)
             .Produces(404).Produces(500);

            app.MapPost("/customer/add", async (ICustomerService customerService, CustomerDto customerDto) =>
            {
                var response = await customerService.Add(customerDto).ConfigureAwait(false);
                return response;

            }).WithName("AddCustomer").WithTags("External-Services")
             .Produces(400).Produces(200)
             .Produces(404).Produces(500);

            app.MapPut("/customer/update", async (ICustomerService customerService, CustomerDto customerDto) =>
            {
                var response = await customerService.Update(customerDto).ConfigureAwait(false);
                return response;

            }).WithName("UpdateCustomer").WithTags("External-Services")
             .Produces(400).Produces(200)
             .Produces(404).Produces(500);

            app.MapDelete("/customer/delete", async (ICustomerService customerService, int id) =>
            {
                var response = await customerService.Delete(id).ConfigureAwait(false);
                return response;

            }).WithName("DeleteCustomer").WithTags("External-Services")
             .Produces(400).Produces(200)
             .Produces(404).Produces(500);
        }
    }
}
