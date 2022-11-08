using Microsoft.Build.Framework;

namespace ApiSampleProject.Models.DTOs;

public class CustomerDto
{
    [Required] public int Id { get; set; }

    public string Name { get; set; }
}