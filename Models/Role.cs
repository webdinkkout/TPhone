using System.ComponentModel.DataAnnotations;
using CellPhoneS.Common;

namespace CellPhoneS.Models;

public class Role
{
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}