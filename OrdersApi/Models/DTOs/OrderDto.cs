using System.ComponentModel.DataAnnotations;

namespace ApiSampleProject.Models.DTOs;

public class OrderDto
{
    [Required] public int Id { get; set; }

    [Required] public Customer Customer { get; set; }

    public string? Note { get; set; }

    public List<Item> Items { get; set; }

    [Required] public DateTime OrderPlacedTimestamp { get; set; }

    public DateTime? DeliveryTimeStamp { get; set; }

    public bool IsComplete => DeliveryTimeStamp == null;
}