using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFood.Data.Models
{
    public class Food
    {
        public int FoodId { get; set; }

        [Column(TypeName = "Varchar(20)")]
        public string FoodName { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string Description  { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ImgUrl  { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
