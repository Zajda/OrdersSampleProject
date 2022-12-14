using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ApiSampleProject.Models.Interfaces;

namespace ApiSampleProject.Models;

public class Order : IBaseModel
{
    [Required] public int Id { get; set; }

    [Required] public Customer Customer { get; set; }

    public string? Note { get; set; }
    
    public List<Item> Items { get; set; }

    [Required] public DateTime OrderPlacedTimestamp { get; set; }

    public DateTime? DeliveryTimeStamp { get; set; }

    public bool IsComplete => DeliveryTimeStamp == null;
    
    public bool IsDeleted { get; set; }
}