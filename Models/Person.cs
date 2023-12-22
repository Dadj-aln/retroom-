using retroom_last.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public int ID { get; set; }
    [Required]
    [DisplayName("نام")]
    public string Fullname { get; set; }
    [Required]
    [EmailAddress]
    [DisplayName("ایمیل")]
    public string Email { get; set; }
    [Required]
    [PasswordPropertyText]
    [DisplayName("رمز عبور")]
    public string Password { get; set; }

    // Key
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Restaurant> Restaurants { get; set; }


}