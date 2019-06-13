using System.ComponentModel.DataAnnotations;

namespace TechLib.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        [StringLength(200, ErrorMessage = "Поле {0} должно быть не длиннее {1} символов.")]
        [Required(ErrorMessage = "Поле {0} обязательное.")]
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int? ReaderId { get; set; }
        public virtual Reader Reader { get; set; }

    }
}
