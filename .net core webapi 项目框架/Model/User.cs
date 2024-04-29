using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.model; 

public class User {
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")] 
    public string? Username { get; set; }
    
    [Column("email")]
    public string? Email { get; set; }
    
    [Column("password")]
    public string? Password { get; set; }
    
    [Column("create_time")]
    public DateTime CreateTime { get; set; } = DateTime.Now;

    [Column("create_user")]
    public string? CreateUser { get; set; }
    
    [Column("update_time")]
    public DateTime? UpdateTime { get; set; } = DateTime.Now;

    [Column("update_user")]
    public string? UpdateUser { get; set; }
}