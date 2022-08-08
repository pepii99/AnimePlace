using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimePlace.Models.InputModels
{

    public enum TypeEnum
    {
        TV = 1,
        Movie = 2
    }


    [Keyless]
    public class CreateAnimeInputModel
    {

        [MinLength(1)]
        [MaxLength(70)]
        [Required]
        public string? Name { get; set; }
        
        [MinLength(1)]
        [MaxLength(70)]
        public string? AlternativeName { get; set; }

        [MinLength(5)]
        [MaxLength(1000)]
        [Required]
        public string? Sypnosis { get; set; }

        [Range(1, 500)]
        [Required]
        public int? Episodes { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Source { get; set; }

        //For example R - 17+ (violence & profanity) / PG-13 - Teens 13 or older
        public string Rating { get; set; }

        [Required]
        public string Aired { get; set; }

        [Required]
        public string Status { get; set; }
        public string BorderImageUrl { get; set; }

        //public IFormFile Image { get; set; }

        [Required]
        public TypeEnum? Type { get; set; }

        //To make it so you can add the characters on anime creation and/or add them eventually
        //public ICollection<AnimeCharacterInputModel> Characters { get; set; }
    }
}
