using Microsoft.Build.Framework;

namespace ApiSampleProject.Models;

public class Item
{
    [Required] public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public int Count { get; set; }
    
    public bool IsDeleted { get; set; }
}