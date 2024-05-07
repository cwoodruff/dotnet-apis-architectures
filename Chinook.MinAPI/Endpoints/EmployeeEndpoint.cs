using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class EmployeeEndpoint
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Employee")
            .RequireCors();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllEmployee(page, pageSize)).WithName("GetEmployees")
            .WithOpenApi();

        group.MapGet("{id}", async (int? id, IChinookSupervisor db) => await db.GetEmployeeById(id)).WithName("GetEmployee")
            .WithOpenApi();

        group.MapPost("",
            async ([FromBody] EmployeeApiModel employee, IChinookSupervisor db) => await db.AddEmployee(employee)).WithName("AddEmployee")
            .WithOpenApi();

        group.MapPut("",
            async ([FromBody] EmployeeApiModel employee, IChinookSupervisor db) => await db.UpdateEmployee(employee)).WithName("UpdateEmployee")
            .WithOpenApi();

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteEmployee(id)).WithName("DeleteEmployee")
            .WithOpenApi();

        group.MapGet("directreports/{id}",
            async (int id, IChinookSupervisor db) => await db.GetEmployeeDirectReports(id)).WithName("GetEmployeeDirectReports")
            .WithOpenApi();

        group.MapGet("reportsto/{id}",
            async (int id, IChinookSupervisor db) => await db.GetEmployeeReportsTo(id)).WithName("GetEmployeeDirectReport")
            .WithOpenApi();
    }
}