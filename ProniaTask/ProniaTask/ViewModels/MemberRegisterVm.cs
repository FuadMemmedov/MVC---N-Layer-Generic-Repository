using System.ComponentModel.DataAnnotations;

namespace ProniaTask.ViewModels;

public class MemberRegisterVm
{
    [Required]
    [MaxLength(25)]
    public string Name { get; set; }
    [Required]
    [MaxLength(25)]
    public string Surname { get; set; }
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string RepeatPassword { get; set; }
}
