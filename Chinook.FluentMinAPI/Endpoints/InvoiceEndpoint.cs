using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.FluentMinAPI.Endpoints;

public static class InvoiceEndpoint
{
    public static void MapInvoiceEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Invoice")
            .WithOpenApi();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllInvoice(page, pageSize)).WithName("GetInvoices");

        group.MapGet("{id}", async (int? id, IChinookSupervisor db) => await db.GetInvoiceById(id)).WithName("GetInvoice");

        group.MapPost("",
            async ([FromBody] InvoiceApiModel invoice, IChinookSupervisor db) => await db.AddInvoice(invoice)).WithName("AddInvoice");

        group.MapPut("",
            async ([FromBody] InvoiceApiModel invoice, IChinookSupervisor db) => await db.UpdateInvoice(invoice)).WithName("UpdateInvoice");

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteInvoice(id)).WithName("DeleteInvoice");

        group.MapGet("Customer/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceByCustomerId(id, page, pageSize)).WithName("GetInvoicesForCustomer");

        group.MapGet("Employee/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceByEmployeeId(id, page, pageSize)).WithName("GetInvoicesForEmployee");
    }
}