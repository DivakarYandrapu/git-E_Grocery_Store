using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Models
{
    public class GroceryItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250)]
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
        public string Category { get; set; }
    }
}
