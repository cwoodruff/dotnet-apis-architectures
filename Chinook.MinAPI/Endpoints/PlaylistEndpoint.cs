using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class PlaylistEndpoint
{
    public static void MapPlaylistEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Playlist")
            .RequireCors();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllPlaylist(page, pageSize)).WithName("GetPlaylists")
            .WithOpenApi();

        group.MapGet("{id}", async (int id, IChinookSupervisor db) => await db.GetPlaylistById(id)).WithName("GetPlaylist")
            .WithOpenApi();

        group.MapPost("",
            async ([FromBody] PlaylistApiModel playlist, IChinookSupervisor db) => await db.AddPlaylist(playlist)).WithName("AddPlaylist")
            .WithOpenApi();

        group.MapPut("",
            async ([FromBody] PlaylistApiModel playlist, IChinookSupervisor db) => await db.UpdatePlaylist(playlist)).WithName("UpdatePlaylist")
            .WithOpenApi();

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeletePlaylist(id)).WithName("DeletePlaylist")
            .WithOpenApi();
    }
}