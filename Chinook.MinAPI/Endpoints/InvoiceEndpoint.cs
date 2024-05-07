using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class InvoiceEndpoint
{
    public static void MapInvoiceEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Invoice")
            .RequireCors();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllInvoice(page, pageSize)).WithName("GetInvoices")
            .WithOpenApi();

        group.MapGet("{id}", async (int? id, IChinookSupervisor db) => await db.GetInvoiceById(id)).WithName("GetInvoice")
            .WithOpenApi();

        group.MapPost("",
            async ([FromBody] InvoiceApiModel invoice, IChinookSupervisor db) => await db.AddInvoice(invoice)).WithName("AddInvoice")
            .WithOpenApi();

        group.MapPut("",
            async ([FromBody] InvoiceApiModel invoice, IChinookSupervisor db) => await db.UpdateInvoice(invoice)).WithName("UpdateInvoice")
            .WithOpenApi();

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteInvoice(id)).WithName("DeleteInvoice")
            .WithOpenApi();

        group.MapGet("Customer/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceByCustomerId(id, page, pageSize)).WithName("GetInvoicesForCustomer")
            .WithOpenApi();

        group.MapGet("Employee/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceByEmployeeId(id, page, pageSize)).WithName("GetInvoicesForEmployee")
            .WithOpenApi();
    }
}