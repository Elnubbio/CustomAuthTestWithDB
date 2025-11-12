using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomAuthTestWithDB.Models;

public class UserAccountPolicy
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserAccountId { get; set; }
    public string? UserPolicy { get; set; }
    public bool IsEnabled { get; set; }
}