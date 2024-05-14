using System.ComponentModel.DataAnnotations;

namespace ProniaTask.ViewModels;

public class AdminLoginVm
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; }
    public bool IsPersistent { get; set; }

}
