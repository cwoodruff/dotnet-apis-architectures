using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.FluentMinAPI.Endpoints;

public static class AlbumEndpoint
{
    public static void MapAlbumEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Albums")
            .WithOpenApi();
        
        group.MapGet("",
                async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllAlbum(page, pageSize)).WithName("GetAlbums");

        group.MapGet("{id}", async (int? id, IChinookSupervisor db) => await db.GetAlbumById(id)).WithName("GetAlbum");

        group.MapPost("",
                async ([FromBody] AlbumApiModel album, IChinookSupervisor db) => await db.AddAlbum(album)).WithName("AddAlbum");

        group.MapPut("",
                async ([FromBody] AlbumApiModel album, IChinookSupervisor db) => await db.UpdateAlbum(album)).WithName("UpdateAlbum");

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteAlbum(id)).WithName("DeleteAlbum");

        group.MapGet("Artist/{id}",
                async (int id, int page, int pageSize, IChinookSupervisor db) =>
                    await db.GetAlbumByArtistId(id, page, pageSize)).WithName("GetAlbumsByArtist");
    }
}