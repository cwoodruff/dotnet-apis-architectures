using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class InvoiceLineEndpoint
{
    public static void MapInvoiceLineEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/InvoiceLine")
            .RequireCors();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllInvoiceLine(page, pageSize)).WithName("GetInvoiceLines")
            .WithOpenApi();

        group.MapGet("{id}", async (int id, IChinookSupervisor db) => await db.GetInvoiceLineById(id)).WithName("GetInvoiceLine")
            .WithOpenApi();

        group.MapPost("",
            async ([FromBody] InvoiceLineApiModel invoiceLine, IChinookSupervisor db) =>
            await db.AddInvoiceLine(invoiceLine)).WithName("AddInvoiceLine")
            .WithOpenApi();

        group.MapPut("",
            async ([FromBody] InvoiceLineApiModel invoiceLine, IChinookSupervisor db) =>
            await db.UpdateInvoiceLine(invoiceLine)).WithName("UpdateInvoiceLine")
            .WithOpenApi();

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteInvoiceLine(id)).WithName("DeleteInvoiceLine")
            .WithOpenApi();

        group.MapGet("Invoice/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceLineByInvoiceId(id, page, pageSize)).WithName("GetInvoiceLineForInvoice")
            .WithOpenApi();

        group.MapGet("Track/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetInvoiceLineByTrackId(id, page, pageSize)).WithName("GetInvoiceLineForTrack")
            .WithOpenApi();
    }
}