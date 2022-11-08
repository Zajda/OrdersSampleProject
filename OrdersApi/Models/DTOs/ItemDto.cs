using Microsoft.Build.Framework;

namespace ApiSampleProject.Models.DTOs;

public class ItemDto
{
    [Required] public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public int Count { get; set; }
}