using AmdarisProject.Common.Dtos;
using Newtonsoft.Json;

using var httpClient = new HttpClient();

while (true)
{
    var response = await httpClient.GetStringAsync(Console.ReadLine());

    Console.WriteLine();

    var hostels = JsonConvert.DeserializeObject<List<HostelDto>>(response);

    foreach (var hostelDto in hostels)
    {
        Console.WriteLine($"Hostel number: {hostelDto.HostelNumber}");
    }
}