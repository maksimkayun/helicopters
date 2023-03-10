using System.Text.Json.Serialization;

namespace HelicoptersService.Contracts;

public class ReadHelicoptersListRequest
{
    public int Take { get; set; }
    public int Skip { get; set; }

    [JsonIgnore]
    private int DefaultTake = 20;
}