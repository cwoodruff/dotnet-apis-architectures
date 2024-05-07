using Chinook.Domain.ApiModels;
using Chinook.Domain.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.MinAPI.Endpoints;

public static class TrackEndpoint
{
    public static void MapTrackEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Track")
            .RequireCors();

        group.MapGet("",
            async (int page, int pageSize, IChinookSupervisor db) => await db.GetAllTrack(page, pageSize)).WithName("GetTracks")
            .WithOpenApi();

        group.MapGet("{id}", async (int? id, IChinookSupervisor db) => await db.GetTrackById(id)).WithName("GetTrack")
            .WithOpenApi();

        group.MapPost("",
            async ([FromBody] TrackApiModel track, IChinookSupervisor db) => await db.AddTrack(track)).WithName("AddTrack")
            .WithOpenApi();

        group.MapPut("",
            async ([FromBody] TrackApiModel track, IChinookSupervisor db) => await db.UpdateTrack(track)).WithName("UpdateTrack")
            .WithOpenApi();

        group.MapDelete("{id}", async (int id, IChinookSupervisor db) => await db.DeleteTrack(id)).WithName("DeleteTrack")
            .WithOpenApi();

        group.MapGet("Artist/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByArtistId(id, page, pageSize)).WithName("GetTracksForArtist")
            .WithOpenApi();

        group.MapGet("Album/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByAlbumId(id, page, pageSize)).WithName("GetTracksForAlbum")
            .WithOpenApi();

        group.MapGet("Genre/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByGenreId(id, page, pageSize)).WithName("GetTracksForGenre")
            .WithOpenApi();

        group.MapGet("Invoice/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByInvoiceId(id, page, pageSize)).WithName("GetTracksForInvoice")
            .WithOpenApi();

        group.MapGet("MediaType/{id}",
            async (int id, int page, int pageSize, IChinookSupervisor db) =>
                await db.GetTrackByMediaTypeId(id, page, pageSize)).WithName("GetTracksForMediaType")
            .WithOpenApi();
    }
}