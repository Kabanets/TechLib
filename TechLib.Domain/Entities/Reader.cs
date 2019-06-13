using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechLib.Domain.Entities
{
    public class Reader
    {
        public int ReaderId { get; set; }

        [StringLength(100, ErrorMessage = "Поле {0} должно быть не длиннее {1} символов.")]
        [Required(ErrorMessage = "Поле {0} обязательное.")]
        public string FName { get; set; }

        [StringLength(100, ErrorMessage = "Поле {0} должно быть не длиннее {1} символов.")]
        [Required(ErrorMessage = "Поле {0} обязательное.")]
        public string LName { get; set; }

        public virtual List<Book> Books { get; set; } = new List<Book>();
    }
}
