using retroom_last.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class Restaurant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    [DisplayName("نام")]
    public string Name { get; set; }
    [DisplayName("توضیخات")]
    public string Description { get; set; }
    [DisplayName("شماره تلفن")]
    public string Phone { get; set; }
    [DisplayName("استان")]
    public string Province { get; set; }
    [DisplayName("شهر")]
    public string City { get; set; }
    [DisplayName("ادرس")]
    public string Address { get; set; }
    [NotMapped]  // Exclude from database mapping if you are using EF Core
    [DisplayName("تصویر")]
    [AllowNull]
    public IFormFile ImageFile { get; set; }
    public string ImagePath { get; set; }
    // Key
    [AllowNull]
    public virtual ICollection<Comment> Comments { get; set; }
    public int? PersonID { get; set; }
    [ForeignKey("PersonID")]
    public Person? Person { get; set; }

}