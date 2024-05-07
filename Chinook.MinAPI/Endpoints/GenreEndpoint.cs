using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class GenreEndpoint
{
    public static void MapGenreEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Genre")
            .WithOpenApi();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllGenre(page, pageSize)).WithName("GetGenres");

        group.MapGet("{id}", async (int? id, IChinookSupervisor db) => await db.GetGenreById(id)).WithName("GetGenre");

        group.MapPost("",
            async ([FromBody] GenreApiModel genre, IChinookSupervisor db) => await db.AddGenre(genre)).WithName("AddGenre");

        group.MapPut("",
            async ([FromBody] GenreApiModel genre, IChinookSupervisor db) => await db.UpdateGenre(genre)).WithName("UpdateGenre");

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteGenre(id)).WithName("DeleteGenre");
    }
}