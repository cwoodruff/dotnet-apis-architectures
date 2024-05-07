using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class EmployeeEndpoint
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Employee")
            .WithOpenApi();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllEmployee(page, pageSize)).WithName("GetEmployees");

        group.MapGet("{id}", async (int? id, IChinookSupervisor db) => await db.GetEmployeeById(id)).WithName("GetEmployee");

        group.MapPost("",
            async ([FromBody] EmployeeApiModel employee, IChinookSupervisor db) => await db.AddEmployee(employee)).WithName("AddEmployee");

        group.MapPut("",
            async ([FromBody] EmployeeApiModel employee, IChinookSupervisor db) => await db.UpdateEmployee(employee)).WithName("UpdateEmployee");

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteEmployee(id)).WithName("DeleteEmployee");

        group.MapGet("directreports/{id}",
            async (int id, IChinookSupervisor db) => await db.GetEmployeeDirectReports(id)).WithName("GetEmployeeDirectReports");

        group.MapGet("reportsto/{id}",
            async (int id, IChinookSupervisor db) => await db.GetEmployeeReportsTo(id)).WithName("GetEmployeeDirectReport");
    }
}