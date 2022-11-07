using Microsoft.Build.Framework;

namespace ApiSampleProject.Models;

public class Customer
{
    [Required] public int Id { get; set; }

    public string Name { get; set; }
}