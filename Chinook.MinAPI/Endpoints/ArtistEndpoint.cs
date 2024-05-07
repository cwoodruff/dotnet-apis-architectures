using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class ArtistEndpoint
{
    public static void MapArtistEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Artists")
            .WithOpenApi();
        
        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllAlbum(page, pageSize)).WithName("GetArtists");

        group.MapGet("{id}", async (int id, IChinookSupervisor db) => await db.GetArtistById(id)).WithName("GetArtist");

        group.MapPost("",
            async ([FromBody] ArtistApiModel artist, IChinookSupervisor db) => await db.AddArtist(artist)).WithName("AddArtist");

        group.MapPut("",
            async ([FromBody] ArtistApiModel artist, IChinookSupervisor db) => await db.UpdateArtist(artist)).WithName("UpdateArtist");

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteArtist(id)).WithName("DeleteArtist");
    }
}