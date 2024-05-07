using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class ArtistEndpoint
{
    public static void MapArtistEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Artists")
            .RequireCors();
        
        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllAlbum(page, pageSize)).WithName("GetArtists")
            .WithOpenApi();

        group.MapGet("{id}", async (int id, IChinookSupervisor db) => await db.GetArtistById(id)).WithName("GetArtist")
            .WithOpenApi();

        group.MapPost("",
            async ([FromBody] ArtistApiModel artist, IChinookSupervisor db) => await db.AddArtist(artist)).WithName("AddArtist")
            .WithOpenApi();

        group.MapPut("",
            async ([FromBody] ArtistApiModel artist, IChinookSupervisor db) => await db.UpdateArtist(artist)).WithName("UpdateArtist")
            .WithOpenApi();

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteArtist(id)).WithName("DeleteArtist")
            .WithOpenApi();
    }
}