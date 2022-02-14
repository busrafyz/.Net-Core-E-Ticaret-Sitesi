using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFood.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz!")]
        [StringLength(20, ErrorMessage ="Kategori adı 3-20 karakterden oluşmalıdır!", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public List<Food> Foods { get; set; }
    }
}
