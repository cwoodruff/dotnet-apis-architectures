using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class CustomerEndpoint
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Customers")
            .WithOpenApi();
        
        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllCustomer(page, pageSize)).WithName("GetCustomers");

        group.MapGet("{id}", async (int id, IChinookSupervisor db) => await db.GetCustomerById(id)).WithName("GetCustomer");

        group.MapPost("",
            async ([FromBody] CustomerApiModel customer, IChinookSupervisor db) => await db.AddCustomer(customer)).WithName("AddCustomer");

        group.MapPut("",
            async ([FromBody] CustomerApiModel customer, IChinookSupervisor db) => await db.UpdateCustomer(customer)).WithName("UpdateCustomer");

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteCustomer(id)).WithName("DeleteCustomer");

        group.MapGet("SupportRep/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetCustomerBySupportRepId(id, page, pageSize)).WithName("GetCustomersForSupportRep");
    }
}