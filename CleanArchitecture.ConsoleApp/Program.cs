using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();


QueryStreaming();

Console.WriteLine("presiones cualquier tecla para terminar");
Console.ReadKey();


void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Nombre} - {streamer.Id}");
    }
}

async Task saveRecords()
{
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
}