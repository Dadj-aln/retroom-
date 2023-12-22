using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace retroom_last.Models
{
    public class Comment
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [AllowNull]
        [DisplayName("نظر")]
        public string? CommentContent { get; set; }
        [DisplayName("کیفیت")]
        
        public int? Quality { get; set; }
        [DisplayName("طعم")]
        public int? Taste { get; set; }
        [DisplayName("نظافت")]
        public int? Clean { get; set; }
        [DisplayName("ارزش خرید")]
        public int? PriceWorth { get; set; }

        

        // Foreign key to User
        public int PersonID { get; set; }
            [ForeignKey("PersonID")]
            public Person Person { get; set; } 

            // Foreign key to Restaurant
            public int RestaurantID { get; set; }
            [ForeignKey("RestaurantID")]    
            public Restaurant Restaurant { get; set; }
         
           


    }
}

