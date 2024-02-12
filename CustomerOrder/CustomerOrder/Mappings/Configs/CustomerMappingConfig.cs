using CustomerOrder.Application.Services.CustomerServices.Commands.CreateCustomer;
using CustomerOrder.Application.Services.CustomerServices.Commands.DeleteCustomer;
using CustomerOrder.Application.Services.CustomerServices.Commands.UpdateCustomer;
using CustomerOrder.Application.Services.CustomerServices.Common;
using CustomerOrder.Contracts.Customer;
using CustomerOrder.Contracts.Customer.Requests;
using CustomerOrder.Contracts.Customer.Responses;
using Mapster;
namespace CustomerOrder.Api.Mappings.Configs
{
    public class CustomerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateCustomerRequest, CreateCustomerCommand>();
            config.NewConfig<CreateCustomerResult, CreateCustomerResponse>();

            config.NewConfig<DeleteCustomerRequest, DeleteCustomerCommand>();
            config.NewConfig<DeleteCustomerResult, DeleteCustomerResponse>();

            config.NewConfig<UpdateCustomerRequest, UpdateCustomerCommand>();
            config.NewConfig<UpdateCustomerResult, UpdateCustomerResponse>();

        }
    }
}
