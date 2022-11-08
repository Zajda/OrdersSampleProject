using ApiSampleProject.Models.Interfaces;
using Microsoft.Build.Framework;

namespace ApiSampleProject.Models;

public class Customer : IBaseModel
{
    [Required] public int Id { get; set; }

    public string Name { get; set; }
    
    public bool IsDeleted { get; set; }
}