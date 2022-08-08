using System.ComponentModel.DataAnnotations;

namespace AnimePlace.Models.InputModels
{
    public class AnimeCharacterInputModel
    {
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public string Voice { get; set; }
    }
}
