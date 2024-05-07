using Chinook.MinAPI.Bootstrapper;
using Chinook.MinAPI.Endpoints;

var app = AppBuilder.GetApp(args);

// Configure Request Pipeline
RequestPipelineBuilder.Configure(app);

// Configure APIs 
app.MapAlbumEndpoints();
app.MapArtistEndpoints();
app.MapCustomerEndpoints();
app.MapEmployeeEndpoints();
app.MapGenreEndpoints();
app.MapInvoiceEndpoints();
app.MapInvoiceLineEndpoints();
app.MapMediaTypeEndpoints();
app.MapPlaylistEndpoints();
app.MapTrackEndpoints();

// Start the app
app.Run();