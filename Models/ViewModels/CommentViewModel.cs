using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace retroom_last.Models
{
    public class CommentViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required(ErrorMessage = "Comment content is required.")]
        public string CommentContent { get; set; }

        [Required(ErrorMessage = "Quality is required.")]
        public int Quality { get; set; }

        [Required(ErrorMessage = "Taste is required.")]
        public int Taste { get; set; }

        [Required(ErrorMessage = "Clean is required.")]
        public int Clean { get; set; }

        [Required(ErrorMessage = "Price worth is required.")]
        public int PriceWorth { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }

        // Additional properties for drop-down lists
        public SelectList Scores { get; set; } = new SelectList(new[] { 1, 2, 3, 4, 5 });
        
    }
}
