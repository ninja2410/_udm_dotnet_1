using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();


//QueryStreaming();
await queryFilter();

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

async Task queryFilter()
{
    Console.WriteLine("Ingrese una compania de streaming:");
    var streamingNombre = Console.ReadLine();
    var streamers = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre, $"%{streamingNombre}%")).ToListAsync();
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