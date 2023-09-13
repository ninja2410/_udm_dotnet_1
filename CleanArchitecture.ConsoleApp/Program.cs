using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();

Streamer streamer = new()
{
    Nombre = "Amazon Prime",
    Url = "https://www.amazonprime.com"
};

dbContext!.Streamers!.Add(streamer);
await dbContext.SaveChangesAsync();

var movies = new List<Video>
{
    new Video
    {
        Nombre= "Mad max",
        StreamerId=streamer.Id
    },
    new Video
    {
        Nombre= "Bathman",
        StreamerId=streamer.Id
    },
    new Video
    {
        Nombre= "Guason",
        StreamerId=streamer.Id
    },
};

await dbContext.AddRangeAsync(movies);
await dbContext.SaveChangesAsync();