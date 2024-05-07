using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class MediaTypeEndpoint
{
    public static void MapMediaTypeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/MediaType")
            .RequireCors();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllMediaType(page, pageSize)).WithName("GetMediaTypes")
            .WithOpenApi();

        group.MapGet("{id}", async (int? id, IChinookSupervisor db) => await db.GetMediaTypeById(id)).WithName("GetMediaType")
            .WithOpenApi();

        group.MapPost("",
            async ([FromBody] MediaTypeApiModel mediaType, IChinookSupervisor db) => await db.AddMediaType(mediaType)).WithName("AddMediaType")
            .WithOpenApi();

        group.MapPut("",
            async ([FromBody] MediaTypeApiModel mediaType, IChinookSupervisor db) =>
            await db.UpdateMediaType(mediaType)).WithName("UpdateMediaType")
            .WithOpenApi();

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteMediaType(id)).WithName("DeleteMediaType")
            .WithOpenApi();
    }
}