using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimePlace.Models
{
    [Keyless]
    public class IndexViewModel
    {
        public int AnimesCount { get; set; }
        
        public int GenresCount { get; set; }
       
        public int CharactersCount { get; set; }
        
        public int StudiosCount { get; set; }
    }
}
