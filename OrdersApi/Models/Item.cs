using ApiSampleProject.Models.Interfaces;
using Microsoft.Build.Framework;

namespace ApiSampleProject.Models;

public class Item : IBaseModel
{
    [Required] public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public int Count { get; set; }
    
    public bool IsDeleted { get; set; }
}