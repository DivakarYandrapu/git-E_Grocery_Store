using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Models
{
    public class RatingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Quality { get; set; }

    }
}
