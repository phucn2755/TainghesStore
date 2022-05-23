using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TainghesStore.Models
{
    public class Tainghe
    {
        [Display(Name = "Mã")]
        public int Id { get; set; }
        [Display(Name = "Tên")]
        public string Title { get; set; }
        [Display(Name = "Loại")]
        public string Genre { get; set; }
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}
