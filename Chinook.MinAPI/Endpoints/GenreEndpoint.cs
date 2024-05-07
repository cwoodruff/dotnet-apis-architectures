using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class GenreEndpoint
{
    public static void MapGenreEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Genre")
            .RequireCors();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllGenre(page, pageSize)).WithName("GetGenres")
            .WithOpenApi();

        group.MapGet("{id}", async (int? id, IChinookSupervisor db) => await db.GetGenreById(id)).WithName("GetGenre")
            .WithOpenApi();

        group.MapPost("",
            async ([FromBody] GenreApiModel genre, IChinookSupervisor db) => await db.AddGenre(genre)).WithName("AddGenre")
            .WithOpenApi();

        group.MapPut("",
            async ([FromBody] GenreApiModel genre, IChinookSupervisor db) => await db.UpdateGenre(genre)).WithName("UpdateGenre")
            .WithOpenApi();

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteGenre(id)).WithName("DeleteGenre")
            .WithOpenApi();
    }
}