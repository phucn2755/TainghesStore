using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TainghesStore.Models
{
    public class GenreViewModel
    {
        public List<Tainghe>? Tainghes { get; set; }
        public SelectList? Genres { get; set; }
        public string? TaingheGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
