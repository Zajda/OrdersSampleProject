using System.ComponentModel;

namespace ApiSampleProject.Models.Interfaces;

public interface IBaseModel
{
    public int Id { get; set; }
    
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
}